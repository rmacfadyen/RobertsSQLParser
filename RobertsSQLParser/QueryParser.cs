using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

[assembly: CLSCompliant(true)]
namespace RobertsSQLParser
{

    public class PermittedItems
    {
        /// <summary>
        /// Map of user defined function names and the number of arguments each take
        /// </summary>
        public IDictionary<string, int> UserDefinedFunctions { get; } = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// List of user defined variable names
        /// </summary>
        public ICollection<string> Variables { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// List of regular expressions that match permitted schema items, like
        /// column names or table and column names.
        /// </summary>
        public IList<Regex> PermittedColumns { get; } = new List<Regex>();
    }


    public interface IQueryParser
    {
        PermittedItems Permitted { get; }
        (bool IsSafe, string ErrorDetails, string SafeSql) CriteriaToSafeSql(string Query, IDictionary<string, string> ColumnNameReplacementsMap = null);
        (bool IsSafe, string ErrorDetails, string SafeSql) SelectToSafeSql(string Query, IDictionary<string, string> ColumnNameReplacementsMap = null);
    }


    public class QueryParser : IQueryParser
    {

        public PermittedItems Permitted { get; } = new PermittedItems();


        public QueryParser()
        {

        }



        public (bool IsSafe, string ErrorDetails, string SafeSql) SelectToSafeSql(
           string Query,
           IDictionary<string, string> ColumnNameReplacementsMap = null)
        {
            return ToSafeSql(Query, ColumnNameReplacementsMap, (p) => p.select_stmt());
        }


        public (bool IsSafe, string ErrorDetails, string SafeSql) CriteriaToSafeSql(
            string Query,
            IDictionary<string, string> ColumnNameReplacementsMap = null)
        {
            return ToSafeSql(Query, ColumnNameReplacementsMap, (p) => p.root());
        }



        private (bool IsSafe, string ErrorDetails, string SafeSql) ToSafeSql(
            string Query,
            IDictionary<string, string> ColumnNameReplacementsMap, Func<SqlParser, IParseTree> GetParserRoot)
        {
            _ = Query ?? throw new ArgumentNullException(nameof(Query));

            //
            // Parse the query
            //
            var (errors, tree, TokenStream) = DoParse(Query, GetParserRoot);
            if (errors.Count != 0)
            {
                return (false, errors.First(), null);
            }

            //
            // Translate the tree back into a string
            //
            var SafeSql = SafeSqlConverter.OutputTree(tree, TokenStream, ColumnNameReplacementsMap);

            //
            // Success
            //
            return (true, null, SafeSql.Trim());
        }



        private (IList<string> errors, IParseTree tree, CommonTokenStream TokenStream) DoParse(string Query, Func<SqlParser, IParseTree> GetParserRoot)
        {
            //
            // Setup the parser
            //
            var InputStream = new AntlrInputStream(Query);
            var LexerStdOut = new StringWriter();
            var LexerStdErr = new StringWriter();
            var lexer = new SqlLexer(InputStream, LexerStdOut, LexerStdErr);

            var TokenStream = new CommonTokenStream(lexer);
            var ParserStdOut = new StringWriter();
            var ParserStdErr = new StringWriter();
            var parser = new SqlParser(TokenStream, ParserStdOut, ParserStdErr);

            var ParserErrorListener = new ErrorListener();
            parser.AddErrorListener(ParserErrorListener);

            var LexerErrorListener = new LexErrorListener();
            lexer.AddErrorListener(LexerErrorListener);

            //
            // Requesting the root node initiates the parsing
            //
            var tree = GetParserRoot(parser); // parser.select_stmt();

            //
            // The myriad ways an error could be reported
            //
            if (ParserErrorListener.Errors.Count != 0)
            {
                return (ParserErrorListener.Errors, null, null);
            }
            if (LexerErrorListener.Errors.Count != 0)
            {
                return (LexerErrorListener.Errors, null, null);
            }
            if (LexerStdErr.ToString() != "")
            {
                return (LexerStdErr.ToString().Split('\n').ToList(), null, null);
            }
            if (ParserStdErr.ToString() != "")
            {
                return (ParserStdErr.ToString().Split('\n').ToList(), null, null);
            }

            //
            // Syntax is good, time for more complicated validations
            //
            var Analyzer = new SemanticAnalysis(Permitted.UserDefinedFunctions, Permitted.Variables, Permitted.PermittedColumns);
            Analyzer.Visit(tree);
            if (Analyzer.Errors.Any())
            {
                return (Analyzer.Errors, null, null);
            }

            //
            // Success
            //
            return (new List<string>(), tree, TokenStream);
        }
    }
}

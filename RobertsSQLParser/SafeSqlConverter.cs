using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace RobertsSQLParser
{
    internal static class SafeSqlConverter
    {

        public static string OutputTree(
            IParseTree rootOfTree, 
            CommonTokenStream tokenStream, 
            IDictionary<string, string> ColumnNameReplacementsMap)
        {
            var sb = new StringBuilder();

            OutputNode(rootOfTree, sb, tokenStream, ColumnNameReplacementsMap);
            
            return sb.ToString();
        }


        private static void OutputNode(
            IParseTree node, 
            StringBuilder sb, 
            BufferedTokenStream tokenStream,
            IDictionary<string, string> FriendlyNameToInternalNameMap)
        {
            //
            // Ignore the EOF token
            //
            var terminalNode = node as ITerminalNode;
            if (terminalNode != null && terminalNode.Symbol.Type == -1)
            {
                return;
            }
            
            //
            // Only terminal (aka leaf) nodes generate output
            //  - intermediate nodes, like "expr" for example, don't actually have
            //    a string representation... their child nodes, or grand-children,
            //    have a string representation (excep for column names which we
            //    do a bit of processing on before outputing).
            //
            if (terminalNode != null)
            {
                //
                // Hidden tokens to the left means any preceeding whitespace and/or single line comment
                //
                WhiteSpaceToTheLeft(sb, tokenStream, terminalNode);

                //
                // Except for the EOF node output this node's text
                //
                if (terminalNode.Symbol.Type != -1)
                {
                    sb.Append(terminalNode.GetText());
                }
            }

            //
            // Do all the child nodes
            //
            for (var i = 0; i < node.ChildCount; i += 1)
            {
                //
                // Handle non-column name nodes via OutputNode. Column identifiers
                // are handle here and don't need recursion.
                //
                var Child = node.GetChild(i);
                if (Child is SqlParser.Qualified_column_nameContext)
                {
                    OutputColumnName(sb, tokenStream, FriendlyNameToInternalNameMap, Child);
                }
                else
                {
                    OutputNode(Child, sb, tokenStream, FriendlyNameToInternalNameMap);
                }
            }
        }


        private static void OutputColumnName(StringBuilder sb, BufferedTokenStream tokenStream, IDictionary<string, string> FriendlyNameToInternalNameMap, IParseTree Child)
        {
            //
            // Any whitespace on the left should be added back
            //
            var LeftTerminalNode = GetLeftMostTerminalNode(Child);
            WhiteSpaceToTheLeft(sb, tokenStream, LeftTerminalNode);

            //
            // Handle each part of the column name
            //
            string ColumnName = "";
            foreach (var child in (Child as SqlParser.Qualified_column_nameContext).children)
            {
                if (child is ITerminalNode n && n.Symbol.Type == SqlLexer.DOT)
                {
                    ColumnName += child.GetText();
                }
                else if (child is SqlParser.Database_nameContext
                    || child is SqlParser.Schema_nameContext
                    || child is SqlParser.Table_nameContext
                    || child is SqlParser.Column_nameContext)
                {
                    var NodeText = child.GetText();

                    //
                    // Handle translating friendly column names to internal column names
                    //
                    if (child is SqlParser.Column_nameContext)
                    {
                        //
                        // If there's a translation map and this column is in it... use the new value
                        //
                        if (FriendlyNameToInternalNameMap != null && FriendlyNameToInternalNameMap.ContainsKey(NodeText))
                        {
                            NodeText = FriendlyNameToInternalNameMap[NodeText];
                        }
                    }

                    ColumnName += NodeText;
                }
            }

            sb.Append(ColumnName);
        }

        static ITerminalNode GetLeftMostTerminalNode(IParseTree tree)
        {
            var node = tree.GetChild(0);
            if (node is ITerminalNode)
            {
                return node as ITerminalNode;
            }
            else
            {
                return GetLeftMostTerminalNode(node);
            }
        }


        private static void WhiteSpaceToTheLeft(StringBuilder sb, BufferedTokenStream tokenStream, ITerminalNode terminalNode)
        {
            var tokensToTheLeft = tokenStream.GetHiddenTokensToLeft(terminalNode.Symbol.TokenIndex);
            if (tokensToTheLeft != null)
            {
                foreach (var t in tokensToTheLeft)
                {
                    if (t.Type == SqlLexer.SPACES)
                    {
                        sb.Append(t.Text);
                    }
                }
            }
        }
    }
}

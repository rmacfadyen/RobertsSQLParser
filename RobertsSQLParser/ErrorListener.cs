using System.Collections.Generic;
using Antlr4.Runtime;
using System.IO;

namespace RobertsSQLParser
{

    public class LexErrorListener : IAntlrErrorListener<int>
    {
        public List<string> Errors { get; } = new List<string>();

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int col, string msg, RecognitionException e)
        {
            var Error = $"Incorrect syntax near '{offendingSymbol}' (column {col}, line {line})";
            Errors.Add(Error);
        }
    }


    /// <summary>
    /// Lots of examples define this class as ErrorListener<T>: SomeBaseClass<T> which
    /// is really wrong. Doing so prevents the listener from getting called for some
    /// types of errors, typically 'extraneous input' errors (where the text just doesn't
    /// match the rules at all). Defining it as ErrorListener: IAntlrErrorListener<IToken>
    /// works (this took about a day to figure out).
    /// </summary>
    public class ErrorListener : IAntlrErrorListener<IToken>
    {
        public List<string> Errors { get; } = new List<string>();

        public void SyntaxError(
            TextWriter output, 
            IRecognizer recognizer, 
            IToken offendingSymbol, 
            int line, int col, 
            string msg, 
            RecognitionException e)
        {
            var l = (line == 1 ? "" : $", line {line}");
            var c = $"(column {col}{l})";

            var s = offendingSymbol.Text;
            if (s == "<EOF>")
            {
                s = $"at the end of the criteria {c}. Is there a missing parenthises or unclosed string?";
            }
            else
            {
                s = $"near '{s}' {c}";
            }
            var Error = $"Incorrect syntax {s}";

            Errors.Add(Error);
        }
    }
}
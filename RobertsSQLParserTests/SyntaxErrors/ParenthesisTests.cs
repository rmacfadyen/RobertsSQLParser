using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.SyntaxErrors
{
    [TestClass]
    public class ParenthesisTests
    {
        [TestMethod]
        public void Unbalanced()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("1 = ((1 + 2)");
            Assert.AreEqual("Incorrect syntax at the end of the criteria (column 12). Is there a missing parenthises or unclosed string?", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void NoClosing()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("1 = (1 + 2");
            Assert.AreEqual("Incorrect syntax at the end of the criteria (column 10). Is there a missing parenthises or unclosed string?", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void Backwards()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("1 = )1 + 2)");
            Assert.AreEqual("Incorrect syntax near ')' (column 4)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleTupleEmptyTuple()
        {
            var p = new RobertsSQLParser.QueryParser();            

            var rc = p.CriteriaToSafeSql("IssueId in ()");
            Assert.AreEqual("Incorrect syntax near ')' (column 12)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleNotTupleEmptyTuple()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("IssueId not in ()");
            Assert.AreEqual("Incorrect syntax near ')' (column 16)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void EmptyArgList()
        {
            var p = new RobertsSQLParser.QueryParser();

            var rc = p.CriteriaToSafeSql("1 = coalesce()");
            Assert.AreEqual("Function coalesce requires at least one argument", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

    }
}

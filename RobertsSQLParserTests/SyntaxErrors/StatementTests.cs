using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.SyntaxErrors
{
    [TestClass]
    public class StatementTests
    {
        [TestMethod]
        public void NoFreeStandingStatement()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("select * from Issues");
            Assert.AreEqual("Incorrect syntax near 'Issues' (column 14)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void NoSemiColonStatements()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("1 = 1 ; select * from Issues");
            Assert.AreEqual("Incorrect syntax near ';' (column 6)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }
    }
}

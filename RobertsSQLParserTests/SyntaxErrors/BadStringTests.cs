using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.SyntaxErrors
{
    [TestClass]
    public class BadStringTests
    {
        [TestMethod]
        public void Unterminated()
        {
            var p = new RobertsSQLParser.QueryParser();            
            var rc = p.CriteriaToSafeSql("1 = 'some unterminated string");
            Assert.AreEqual("Incorrect syntax near ''' (column 4)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void WrongQuotes()
        {
            var p = new RobertsSQLParser.QueryParser();            
            var rc = p.CriteriaToSafeSql("1 = \"abc\"");
            Assert.AreEqual("Incorrect syntax near '\"' (column 4)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }
    }
}

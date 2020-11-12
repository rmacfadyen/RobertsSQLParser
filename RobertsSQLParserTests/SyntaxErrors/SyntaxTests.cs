using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.SyntaxErrors
{
    [TestClass]
    public class SyntaxTests
    {
        [TestMethod]
        public void BackwardsSelectPhrases()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("exists(select * where Id = 1 from Issues)");
            Assert.AreEqual("Incorrect syntax near 'from' (column 29)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void Unbalanced()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("exists(select IssueId xfrom Issues)");
            Assert.AreEqual("Incorrect syntax near 'Issues' (column 28)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }
    }
}

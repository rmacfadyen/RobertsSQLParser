using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.SyntaxErrors
{
    [TestClass]
    public class CommentTests
    {
        [TestMethod]
        public void NoMultilineComments()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("1 = 2 /* comment */");
            Assert.AreEqual("Incorrect syntax near '*' (column 7)", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCompare()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("1 = 2 ");
            Assert.AreEqual("1 = 2", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void NoLineComments()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("1 = 2 -- comment");
            Assert.AreEqual("1 = 2", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

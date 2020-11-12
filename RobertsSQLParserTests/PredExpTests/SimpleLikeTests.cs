using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleLikeTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }
        
        [TestMethod]
        public void SimpleLikeInteger()
        {
            var rc = p.CriteriaToSafeSql("IssueId like 17");
            Assert.AreEqual("IssueId like 17", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleLikeReal()
        {
            var rc = p.CriteriaToSafeSql("IssueId like 17.5");
            Assert.AreEqual("IssueId like 17.5", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleLikeString()
        {
            var rc = p.CriteriaToSafeSql("IssueId like '17'");
            Assert.AreEqual("IssueId like '17'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleLikeField()
        {
            var rc = p.CriteriaToSafeSql("IssueId like ProjectId");
            Assert.AreEqual("IssueId like ProjectId", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleNotLikeField()
        {
            var rc = p.CriteriaToSafeSql("IssueId not like ProjectId");
            Assert.AreEqual("IssueId not like ProjectId", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleLikeEscapedString()
        {
            var rc = p.CriteriaToSafeSql("IssueId like '1''7'");
            Assert.AreEqual("IssueId like '1''7'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleNotBetweenTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }

        [TestMethod]
        public void SimpleNotBetweenInteger()
        {
            var rc = p.CriteriaToSafeSql("IssueId not between 17 and 18");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId not between 17 and 18", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleNotBetweenReal()
        {
            var rc = p.CriteriaToSafeSql("IssueId not between 17.2 and 18.3");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId not between 17.2 and 18.3", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleNotBetweenString()
        {
            var rc = p.CriteriaToSafeSql("IssueId not between '17' and '18'");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId not between '17' and '18'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleNotBetweenStringAndInt()
        {
            var rc = p.CriteriaToSafeSql("IssueId not between '17' and 18");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId not between '17' and 18", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleNotBetweenField()
        {
            var rc = p.CriteriaToSafeSql("IssueId not between ProjectId and IssueId");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId not between ProjectId and IssueId", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleNotBetweenEscapedString()
        {
            var rc = p.CriteriaToSafeSql("IssueId not between '1''7' and 'abc''123'''");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId not between '1''7' and 'abc''123'''", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
    }
}

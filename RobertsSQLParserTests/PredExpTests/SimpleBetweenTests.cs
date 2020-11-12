using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleBetweenTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }


        [TestMethod]
        public void SimpleBetweenInteger()
        {
            var rc = p.CriteriaToSafeSql("IssueId between 17 and 18");
            Assert.AreEqual("IssueId between 17 and 18", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleBetweenReal()
        {
            var rc = p.CriteriaToSafeSql("IssueId between 17.2 and 18.3");
            Assert.AreEqual("IssueId between 17.2 and 18.3", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleBetweenString()
        {
            var rc = p.CriteriaToSafeSql("IssueId between '17' and '18'");
            Assert.AreEqual("IssueId between '17' and '18'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleBetweenField()
        {
            var rc = p.CriteriaToSafeSql("IssueId between ProjectId and IssueId");
            Assert.AreEqual("IssueId between ProjectId and IssueId", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleBetweenEscapedString()
        {
            var rc = p.CriteriaToSafeSql("IssueId between '1''7' and 'abc''123'''");
            Assert.AreEqual("IssueId between '1''7' and 'abc''123'''", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

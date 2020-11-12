using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleTupleTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }


        [TestMethod]
        public void SimpleTupleOneEntryTuple()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (17)");
            Assert.AreEqual("IssueId in (17)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleTupleTwoEntryTuple()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (17, 18)");
            Assert.AreEqual("IssueId in (17, 18)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleNotTupleOneEntryTuple()
        {
            var rc = p.CriteriaToSafeSql("IssueId not in (17)");
            Assert.AreEqual("IssueId not in (17)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleNotTupleTwoEntryTuple()
        {
            var rc = p.CriteriaToSafeSql("IssueId not in (17, 18)");
            Assert.AreEqual("IssueId not in (17, 18)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleTupleUsingSelect()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues)");
            Assert.AreEqual("IssueId in (select IssueId from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleNotTupleUsingSelect()
        {
            var rc = p.CriteriaToSafeSql("IssueId not in (select IssueId from Issues)");
            Assert.AreEqual("IssueId not in (select IssueId from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

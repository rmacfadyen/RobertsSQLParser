using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleCaseTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }

        [TestMethod]
        public void SimpleCase()
        {
            var rc = p.CriteriaToSafeSql("IssueId = case ProjectId when 1 then 2 when 2 then 3 else 4 end");
            Assert.AreEqual("IssueId = case ProjectId when 1 then 2 when 2 then 3 else 4 end", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCaseNoElse()
        {
            var rc = p.CriteriaToSafeSql("IssueId = case ProjectId when 1 then 2 when 2 then 3 end");
            Assert.AreEqual("IssueId = case ProjectId when 1 then 2 when 2 then 3 end", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleSearchedCase()
        {
            var rc = p.CriteriaToSafeSql("IssueId = case when 1 = 1 then 2 when 2 = 2 then 3 else 4 end");
            Assert.AreEqual("IssueId = case when 1 = 1 then 2 when 2 = 2 then 3 else 4 end", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleSearchedCaseNoElse()
        {
            var rc = p.CriteriaToSafeSql("IssueId = case when 1 = 1 then 2 when 2 = 2 then 3 end");
            Assert.AreEqual("IssueId = case when 1 = 1 then 2 when 2 = 2 then 3 end", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

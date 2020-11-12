using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleArthmeticTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }

        [TestMethod]
        public void SimpleMultiply()
        {
            var rc = p.CriteriaToSafeSql("IssueId * 2 = 17");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId * 2 = 17", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleDivide()
        {
            var rc = p.CriteriaToSafeSql("IssueId / 2 = 17.5");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId / 2 = 17.5", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimplePlus()
        {
            var rc = p.CriteriaToSafeSql("IssueId + 2 = '17'");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId + 2 = '17'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleMinus()
        {
            var rc = p.CriteriaToSafeSql("IssueId - 2 = ProjectId");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId - 2 = ProjectId", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleModulus()
        {
            var rc = p.CriteriaToSafeSql("IssueId % 2 = ProjectId");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId % 2 = ProjectId", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleUnaryNegative()
        {
            var rc = p.CriteriaToSafeSql("-1 * 2 = -2");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("-1 * 2 = -2", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
    }
}

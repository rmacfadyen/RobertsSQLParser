using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleIsNullTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }
        
        [TestMethod]
        public void SimpleIsNull()
        {
            var rc = p.CriteriaToSafeSql("IssueId is null");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId is null", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleIsNotNull()
        {
            var rc = p.CriteriaToSafeSql("IssueId is not null");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId is not null", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
    }
}

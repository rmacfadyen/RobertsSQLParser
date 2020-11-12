using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleOrTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }

        [TestMethod]
        public void SimpleOr()
        {
            var rc = p.CriteriaToSafeSql("IssueId = 17 or IssueId = 18");
            Assert.AreEqual("IssueId = 17 or IssueId = 18", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

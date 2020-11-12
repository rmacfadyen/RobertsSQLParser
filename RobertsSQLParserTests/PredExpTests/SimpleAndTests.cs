using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleAndTests
    {
        [TestMethod]
        public void SimpleAnd()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("IssueId = 17 and IssueId = 18");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = 17 and IssueId = 18", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
    }
}

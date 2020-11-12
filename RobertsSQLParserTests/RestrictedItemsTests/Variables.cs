using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.RestrictedItemsTests
{
    [TestClass]
    public class Variables
    {
        [TestMethod]
        public void UnknownVariable()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            p.Permitted.Variables.Add("@CurrentUserId");
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues as i2 where AssignedToUser = @CurrentUserId2)");
            Assert.AreEqual("Unknown variable: @CurrentUserId2", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void NoVariablesPermitted()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues as i2 where AssignedToUser = @CurrentUserId)");
            Assert.AreEqual("Unknown variable: @CurrentUserId", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void CaseInsensitiveVariable()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            p.Permitted.Variables.Add("@CurrentUserId");
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues as i2 where AssignedToUser = @CURRENTUSERID)");
            Assert.AreEqual("exists(select IssueId from Issues as i2 where AssignedToUser = @CURRENTUSERID)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.RestrictedItemsTests
{
    [TestClass]
    public class UserDefinedFunctions
    {
        [TestMethod]
        public void ExplicitlyAllowedFunction()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.Bugger");
            var rc = p.CriteriaToSafeSql("dbo.Bugger(IssueId) = 1");
            Assert.AreEqual("dbo.Bugger(IssueId) = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void UnknownFunction()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.Bugger");
            var rc = p.CriteriaToSafeSql("dbo.Bugger2(IssueId) = 1");
            Assert.AreEqual("Unknown function: dbo.Bugger2", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void NonDboFunction()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.Bugger");
            var rc = p.CriteriaToSafeSql("Bugger(IssueId) = 1");
            Assert.AreEqual("Unknown function: Bugger", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void DifferentOwnerFunction()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.Bugger");
            var rc = p.CriteriaToSafeSql("User.Bugger(IssueId) = 1");
            Assert.AreEqual("Unknown function: User.Bugger", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void CaseInsenitiveFunction()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.BUGGER");
            var rc = p.CriteriaToSafeSql("dbo.Bugger(IssueId) = 1");
            Assert.AreEqual("dbo.Bugger(IssueId) = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void MultipleParameters()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.BUGGER");
            var rc = p.CriteriaToSafeSql("dbo.Bugger(IssueId, ProjectId) = 1");
            Assert.AreEqual("dbo.Bugger(IssueId, ProjectId) = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class AdvancedFilters
    {
        [TestMethod]
        public void Qbsol_ComplicatedAliases()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var rc = p.CriteriaToSafeSql("Issues.IssueId in (select A.IssueId from dbo.QbsIssueProductVersions A where A.ProjectId = 61 and A.QbsProductVersionCode = '5.0.00' and A.QbsBuildVersion = (select max(D.QbsBuildVersion) from dbo.QbsIssueProductVersions D where D.ProjectId = 61 and D.QbsProductVersionCode = '5.0.00'))");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual(           "Issues.IssueId in (select A.IssueId from dbo.QbsIssueProductVersions A where A.ProjectId = 61 and A.QbsProductVersionCode = '5.0.00' and A.QbsBuildVersion = (select max(D.QbsBuildVersion) from dbo.QbsIssueProductVersions D where D.ProjectId = 61 and D.QbsProductVersionCode = '5.0.00'))", rc.SafeSql); 
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void FriendlyName()
        {
            var FriendlyName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"IssueId", "IssueNumber"}
            };

            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var rc = p.CriteriaToSafeSql("Issues.IssueId in (1, 2)", FriendlyName);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("Issues.IssueNumber in (1, 2)", rc.SafeSql);
            Assert.IsTrue(rc.IsSafe);
        }

    }
}

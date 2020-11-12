using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.DateTests
{
    [TestClass]
    public class DetectDateFields
    {
        [TestMethod]
        public void BadQuery()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var UsesDate = p.ReliesOnDate("DateOpened dateadd(dd, 1, getdate()) and dateadd(dd, 2, getdate())", new List<string> { "DateOpened", "DateClosed" });
            Assert.IsFalse(UsesDate);
        }

        [TestMethod]
        public void SimpleDateBetween()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var UsesDate = p.ReliesOnDate("DateOpened between dateadd(dd, 1, getdate()) and dateadd(dd, 2, getdate())", new List<string> { "DateOpened", "DateClosed" });
            Assert.IsTrue(UsesDate);
        }

        [TestMethod]
        public void SimpleDateGt()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var UsesDate = p.ReliesOnDate("GetDate() < DateOpened", new List<string> { "DateOpened", "DateClosed" });
            Assert.IsTrue(UsesDate);
        }

        [TestMethod]
        public void DateIsNull()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var UsesDate = p.ReliesOnDate("DateOpened is null", new List<string> { "DateOpened", "DateClosed" });
            Assert.IsTrue(UsesDate);
        }

        [TestMethod]
        public void DateIsNotNull()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var UsesDate = p.ReliesOnDate("DateOpened is not null", new List<string> { "DateOpened", "DateClosed" });
            Assert.IsTrue(UsesDate);
        }

        [TestMethod]
        public void NoDate()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var UsesDate = p.ReliesOnDate("IssueId < ProjectId", new List<string> { "DateOpened", "DateClosed" });
            Assert.IsFalse(UsesDate);
        }

        [TestMethod]
        public void DateInSubExpression()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var UsesDate = p.ReliesOnDate("IssueId = (select sum(IssueId) from Issues where DateOpened = GetDate())", new List<string> { "DateOpened", "DateClosed" });
            Assert.IsTrue(UsesDate);
        }

        [TestMethod]
        public void DateInSubExpressionSelect()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var UsesDate = p.ReliesOnDate("exists(select DateOpened from Issues where IssueId = 1)", new List<string> { "DateOpened", "DateClosed" });
            Assert.IsFalse(UsesDate);
        }

        [TestMethod]
        public void DateInSubExpressionBasedOnRMTrackSite()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var UsesDate = p.ReliesOnDate("DateTimeLastUpdated > dateadd(mi, 300, (select case when StoreTimesAsUTC = 1 then getutcdate() else getdate() end from RMTrackSite))", new List<string> { "DateTimeLastUpdated" });
            Assert.IsTrue(UsesDate);
        }

    }
}

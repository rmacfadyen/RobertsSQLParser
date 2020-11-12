using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleDateAddTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }

        [TestMethod]
        public void SimpleDateAddUsingYear()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(year, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(year, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingYy()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(yy, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(yy, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingYyyy()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(yyyy, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(yyyy, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingQuarter()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(quarter, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(quarter, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingQq()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(qq, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(qq, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingQ()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(q, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(q, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingMonth()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(month, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(month, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingStringLiteral()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd('month', 1, DateOpened)");
            Assert.AreEqual("The dateadd function's first parameter is invalid", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingStringLiteralExpr()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd('month' + 'n', 1, DateOpened)");
            Assert.AreEqual("The dateadd function's first parameter is invalid", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingMm()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(mm, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(mm, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingM()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(m, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(m, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingDayofyear()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(dayofyear, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(dayofyear, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingDy()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(dy, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(dy, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingY()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(y, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(y, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingDay()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(day, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(day, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingDd()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(dd, 1, DateOpened)");
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = dateadd(dd, 1, DateOpened)", rc.SafeSql);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingD()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(d, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(d, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingWeek()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(week, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(week, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingWk()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(wk, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(wk, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingWw()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(ww, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(ww, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingWeekday()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(weekday, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(weekday, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingDw()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(dw, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(dw, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingHour()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(hour, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(hour, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingHh()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(hh, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(hh, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingMinute()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(minute, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(minute, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingMi()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(mi, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(mi, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingN()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(n, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(n, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingSecond()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(second, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(second, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingSs()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(ss, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(ss, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingS()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(s, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(s, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingMillisecond()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(millisecond, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(millisecond, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingMs()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(ms, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(ms, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingMicrosecond()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(microsecond, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(microsecond, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingMcs()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(mcs, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(mcs, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingNanosecond()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(nanosecond, 1, DateOpened)");
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = dateadd(nanosecond, 1, DateOpened)", rc.SafeSql);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingNs()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(ns, 1, DateOpened)");
            Assert.AreEqual("IssueId = dateadd(ns, 1, DateOpened)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingTzoffset()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(tzoffset, 1, DateOpened)");
            Assert.AreEqual("The dateadd function's first parameter is invalid", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleDateAddUsingTz()
        {
            var rc = p.CriteriaToSafeSql("IssueId = dateadd(tz, 1, DateOpened)");
            Assert.AreEqual("The dateadd function's first parameter is invalid", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }
    }
}

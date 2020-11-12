﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleGreaterThanEqualsTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }

        [TestMethod]
        public void SimpleGreaterThanEqualsInteger()
        {
            var rc = p.CriteriaToSafeSql("IssueId >= 17");
            Assert.AreEqual("IssueId >= 17", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleGreaterThanEqualsReal()
        {
            var rc = p.CriteriaToSafeSql("IssueId >= 17.5");
            Assert.AreEqual("IssueId >= 17.5", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleGreaterThanEqualsString()
        {
            var rc = p.CriteriaToSafeSql("IssueId >= '17'");
            Assert.AreEqual("IssueId >= '17'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleGreaterThanEqualsField()
        {
            var rc = p.CriteriaToSafeSql("IssueId >= ProjectId");
            Assert.AreEqual("IssueId >= ProjectId", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleGreaterThanEqualsEscapedString()
        {
            var rc = p.CriteriaToSafeSql("IssueId >= '1''7'");
            Assert.AreEqual("IssueId >= '1''7'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.DateTests
{

    [TestClass]
    public class QuickAndDirty
    {
        [TestMethod]
        public void TestMethod1()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var UsesDate = p.ReliesOnDate("IssueId <= 17", new List<string>());
            Assert.IsFalse(UsesDate);
        }
    }
}

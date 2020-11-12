using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.LiteralTests
{
    [TestClass]
    public class UnicodeStringTests
    {
        [TestMethod]
        public void CanUseUnicodeStringUpperN()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = N'abc'");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = N'abc'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void CanUseUnicodeStringLowerN()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = n'abc'");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = n'abc'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void CanUseEscapesInUnicodeString()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = n'ab''def'");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = n'ab''def'", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
    }
}

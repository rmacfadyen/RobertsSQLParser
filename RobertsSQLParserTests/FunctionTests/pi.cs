using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.FunctionTests
{
    [TestClass]
    public class pi
    {

        [TestMethod]
        public void pi_valid()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = pi()");
            Assert.AreEqual("1 = pi()", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
        [TestMethod]
        public void pi_invalid_args()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = pi(2)");
            Assert.AreEqual("Function pi requires 0 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.FunctionTests
{
    [TestClass]
    public class getdate
    {
        [TestMethod]
        public void getdate_valid()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = getdate()");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = getdate()", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
        [TestMethod]
        public void getdate_invalid_args()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = getdate(2)");
            Assert.AreEqual("Function getdate requires 0 arguments", rc.ErrorDetails); 
            Assert.IsFalse(rc.IsSafe);
        }
    }
}

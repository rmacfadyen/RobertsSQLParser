using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.FunctionTests
{
    [TestClass]
    public class getutcdate
    {

        [TestMethod]
        public void getutcdate_valid()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var rc = p.CriteriaToSafeSql("1 = getutcdate()");
            Assert.AreEqual(null, rc.ErrorDetails); 
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual("1 = getutcdate()", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
        [TestMethod]
        public void getutcdate_invalid_args()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            var rc = p.CriteriaToSafeSql("1 = getutcdate ( 2 )");
            Assert.AreEqual("Function getutcdate requires 0 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }
    }
}

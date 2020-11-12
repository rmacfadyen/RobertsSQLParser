using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests
{
    /// <summary>
    /// Quick and dirty tests
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }

        [TestMethod]
        public void TestMethod1()
        {
            p.CriteriaToSafeSql("dfhks$^#@*^$* lksjdfj$)*)#*$)");
        }
        
        [TestMethod]
        public void TestMethod2()
        {
            var s = p.SelectToSafeSql("select * from SomeTable", null);
            Assert.AreEqual("select * from SomeTable", s.SafeSql);
        }
    }
}

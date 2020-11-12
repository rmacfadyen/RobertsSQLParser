using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleUserDefinedFunctionTests
    {
        [TestMethod]
        public void SimpleUDF_NoParameters()
        {
            var p = new RobertsSQLParser.QueryParser();            p.Permitted.UserDefinedFunctions.Add("dbo.functionname");
            
            
            var rc = p.CriteriaToSafeSql("1 = dbo.functionname()");
            Assert.AreEqual("1 = dbo.functionname()", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleUDF_1Parameters()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.functionname");
            
            var rc = p.CriteriaToSafeSql("1 = dbo.functionname(ColumnName)");
            Assert.AreEqual("1 = dbo.functionname(ColumnName)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleUDF_2Parameters()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.functionname");

            var rc = p.CriteriaToSafeSql("1 = dbo.functionname(ColumnName, Column2)");
            Assert.AreEqual("1 = dbo.functionname(ColumnName, Column2)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleUDF_3Parameters()
        {
            var p = new RobertsSQLParser.QueryParser();            p.Permitted.UserDefinedFunctions.Add("dbo.functionname");
            
            
            var rc = p.CriteriaToSafeSql("1 = dbo.functionname(ColumnName, Column2, Column3)");
            Assert.AreEqual("1 = dbo.functionname(ColumnName, Column2, Column3)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void UnknownFunction()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("1 = functionname(ColumnName, Column2, Column3)");
            Assert.AreEqual("Unknown function: functionname", rc.ErrorDetails);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.IsFalse(rc.IsSafe);
        }
    }
}

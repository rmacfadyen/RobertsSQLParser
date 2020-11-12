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
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = dbo.functionname()", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleUDF_1Parameters()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.functionname");
            
            var rc = p.CriteriaToSafeSql("1 = dbo.functionname(ColumnName)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = dbo.functionname(ColumnName)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleUDF_2Parameters()
        {
            var p = new RobertsSQLParser.QueryParser();            
            p.Permitted.UserDefinedFunctions.Add("dbo.functionname");

            var rc = p.CriteriaToSafeSql("1 = dbo.functionname(ColumnName, Column2)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = dbo.functionname(ColumnName, Column2)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleUDF_3Parameters()
        {
            var p = new RobertsSQLParser.QueryParser();            p.Permitted.UserDefinedFunctions.Add("dbo.functionname");
            
            
            var rc = p.CriteriaToSafeSql("1 = dbo.functionname(ColumnName, Column2, Column3)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = dbo.functionname(ColumnName, Column2, Column3)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void UnknownFunction()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("1 = functionname(ColumnName, Column2, Column3)");
            Assert.IsFalse(rc.IsSafe);
            Assert.AreEqual(null, rc.SafeSql);
            Assert.AreEqual("Unknown function: functionname", rc.ErrorDetails);
        }

    }
}

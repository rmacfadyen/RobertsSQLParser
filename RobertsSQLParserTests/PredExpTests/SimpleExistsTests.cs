using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleExistsTests
    {
        [TestMethod]
        public void SimpleExists()
        {
            var p = new RobertsSQLParser.QueryParser();            
            
            var rc = p.CriteriaToSafeSql("exists(select * from Issues)");
            Assert.AreEqual("exists(select * from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

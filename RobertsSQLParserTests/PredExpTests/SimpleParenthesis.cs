using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.PredExpTests
{
    internal class SimpleParenthesis
    {
        private RobertsSQLParser.QueryParser p = new RobertsSQLParser.QueryParser();

        [TestMethod]
        public void LotsOfParenthesis()
        {
            var rc = p.CriteriaToSafeSql("((Child + (case when (1 + 2, 23) = 2 then 3 end) + (select 1 + 2 as xxx from something)) = 'Andrew' or Child = 'Kid1') and ..Issues.ResolutionCode = ('To be fixed', 12)");
            Assert.AreEqual(null, rc.ErrorDetails); 
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual("((Child + (case when (1 + 2, 23) = 2 then 3 end) + (select 1 + 2 as xxx from something)) = 'Andrew' or Child = 'Kid1') and ..Issues.ResolutionCode = ('To be fixed', 12)", rc.SafeSql);
        }
    }
}

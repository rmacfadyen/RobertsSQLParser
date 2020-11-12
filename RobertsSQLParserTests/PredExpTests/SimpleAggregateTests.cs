using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleAggregateTests
    {
        private RobertsSQLParser.QueryParser p = new RobertsSQLParser.QueryParser();

        [TestMethod]
        public void SimpleAggregateUsingCountStar()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select COUNT(*) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select COUNT(*) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingCountFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select COUNT(IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select COUNT(IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingCountAllFieldName()
        {
            
            // TODO: grammer is wrong, aggregate functions accept "WORD whitespace colspec"
            var rc = p.CriteriaToSafeSql("1 = (select COUNT(ALL IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select COUNT(ALL IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingCountDistinctFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select COUNT(DISTINCT IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select COUNT(DISTINCT IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


        [TestMethod]
        public void SimpleAggregateUsingAvgFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select AVG(IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select AVG(IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingAvgAllFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select AVG(ALL IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select AVG(ALL IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingAvgDistinctFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select AVG(DISTINCT IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select AVG(DISTINCT IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


        [TestMethod]
        public void SimpleAggregateUsingMinFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select MIN(IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select MIN(IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingMinAllFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select MIN(ALL IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select MIN(ALL IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingMinDistinctFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select MIN(DISTINCT IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select MIN(DISTINCT IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


        [TestMethod]
        public void SimpleAggregateUsingMaxFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select MAX(IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select MAX(IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingMaxAllFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select MAX(ALL IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select MAX(ALL IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingMaxDistinctFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select MAX(DISTINCT IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select MAX(DISTINCT IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


        [TestMethod]
        public void SimpleAggregateUsingStdevFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select STDEV(IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select STDEV(IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingStdevAllFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select STDEV(ALL IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select STDEV(ALL IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingStdevDistinctFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select STDEV(DISTINCT IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select STDEV(DISTINCT IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


        [TestMethod]
        public void SimpleAggregateUsingStdevpFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select STDEVP(IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select STDEVP(IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingStdevpAllFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select STDEVP(ALL IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select STDEVP(ALL IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingStdevpDistinctFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select STDEVP(DISTINCT IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select STDEVP(DISTINCT IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


        [TestMethod]
        public void SimpleAggregateUsingSumFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select SUM(IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select SUM(IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingSumAllFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select SUM(ALL IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select SUM(ALL IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingSumDistinctFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select SUM(DISTINCT IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select SUM(DISTINCT IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


        [TestMethod]
        public void SimpleAggregateUsingVarFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select VAR(IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select VAR(IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingVarAllFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select VAR(ALL IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select VAR(ALL IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingVarDistinctFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select VAR(DISTINCT IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select VAR(DISTINCT IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


        [TestMethod]
        public void SimpleAggregateUsingVarpFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select VARP(IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select VARP(IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingVarpAllFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select VARP(ALL IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select VARP(ALL IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleAggregateUsingVarpDistinctFieldName()
        {
            
            
            var rc = p.CriteriaToSafeSql("1 = (select VARP(DISTINCT IssueId) from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select VARP(DISTINCT IssueId) from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.SelectTests
{
    [TestClass]
    public class FullSelect
    {
        private RobertsSQLParser.QueryParser p;
        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }

        [TestMethod]
        public void InnerJoin()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues inner join Projects on Projects.ProjectId = Issues.ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from Issues inner join Projects on Projects.ProjectId = Issues.ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void InnerJoinToSubquery()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues inner join (select ProjectId, ProjectCode from Projects) as p2 on p2.ProjectId = Issues.ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from Issues inner join (select ProjectId, ProjectCode from Projects) as p2 on p2.ProjectId = Issues.ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
        
        [TestMethod]
        public void Join()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues join Projects on Projects.ProjectId = Issues.ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from Issues join Projects on Projects.ProjectId = Issues.ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void LeftOuterJoin()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues left outer join Projects on Projects.ProjectId = Issues.ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from Issues left outer join Projects on Projects.ProjectId = Issues.ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void LeftJoin()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues left join Projects on Projects.ProjectId = Issues.ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from Issues left join Projects on Projects.ProjectId = Issues.ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void RightOuterJoin()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues right outer join Projects on Projects.ProjectId = Issues.ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from Issues right outer join Projects on Projects.ProjectId = Issues.ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void RightJoin()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues right join Projects on Projects.ProjectId = Issues.ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from Issues right join Projects on Projects.ProjectId = Issues.ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void FullOuterJoin()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues full outer join Projects on Projects.ProjectId = Issues.ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from Issues full outer join Projects on Projects.ProjectId = Issues.ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void FullJoin()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues full join Projects on Projects.ProjectId = Issues.ProjectId)");
            Assert.IsTrue(rc.IsSafe); 
            Assert.AreEqual(null, rc.ErrorDetails); 
            Assert.AreEqual("IssueId in (select IssueId from Issues full join Projects on Projects.ProjectId = Issues.ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


   
        [TestMethod]
        public void CrossJoin()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues cross join Projects)");
            Assert.IsTrue(rc.IsSafe); 
            Assert.AreEqual(null, rc.ErrorDetails); 
            Assert.AreEqual("IssueId in (select IssueId from Issues cross join Projects)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
        
        [TestMethod]
        public void CrossJoinViaComma()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from Issues, Projects)");
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from Issues, Projects)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }



        [TestMethod]
        public void FromSelect()
        {
            var rc = p.CriteriaToSafeSql("IssueId in (select IssueId from (select IssueId as NotIssueId from Issues) as SecondIssues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId in (select IssueId from (select IssueId as NotIssueId from Issues) as SecondIssues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void ExistsWithTableStar()
        {
            var rc = p.CriteriaToSafeSql("exists(select Issues.* from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select Issues.* from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void GroupBy1()
        {
            var rc = p.CriteriaToSafeSql("exists(select max(IssueId) from Issues group by ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select max(IssueId) from Issues group by ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void GroupBy2()
        {
            var rc = p.CriteriaToSafeSql("exists(select max(IssueId) from Issues group by ProjectId, IssueId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select max(IssueId) from Issues group by ProjectId, IssueId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void Having1()
        {
            var rc = p.CriteriaToSafeSql("exists(select max(IssueId) from Issues group by ProjectId having count(*) = 1)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select max(IssueId) from Issues group by ProjectId having count(*) = 1)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void Having2()
        {
            var rc = p.CriteriaToSafeSql("exists(select max(IssueId) from Issues group by ProjectId having count(*) = 1 and max(IssueId) = 2)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select max(IssueId) from Issues group by ProjectId having count(*) = 1 and max(IssueId) = 2)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void OrderBy1()
        {
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues order by ProjectId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues order by ProjectId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void OrderBy2()
        {
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues order by ProjectId, IssueId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues order by ProjectId, IssueId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void OrderByColumnNumber()
        {
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues order by 1)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues order by 1)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void OrderByColumnNumberAsc()
        {
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues order by 1 asc)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues order by 1 asc)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void OrderByColumnNumberDesc()
        {
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues order by 1 desc)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues order by 1 desc)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
        
        [TestMethod]
        public void OrderByCase()
        {
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues order by case when 1 = 2 then 1 else 2 end)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues order by case when 1 = 2 then 1 else 2 end)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void IncorrectUseOfNULL()
        {
            var rc = p.CriteriaToSafeSql("exists(select IssueId from Issues where IssueId = NULL)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues where IssueId = NULL)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void UsingAVariable()
        {
            var parser = new RobertsSQLParser.QueryParser();
            parser.Permitted.PermittedColumns.Add(new Regex(".*"));
            parser.Permitted.Variables.Add("@CurrentUserId");
            
            
            var rc = parser.CriteriaToSafeSql("exists(select IssueId from Issues where AssignedToUser = @CurrentUserId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues where AssignedToUser = @CurrentUserId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void TableAliasImplicit()
        {
            var parser = new RobertsSQLParser.QueryParser();
            parser.Permitted.PermittedColumns.Add(new Regex(".*"));
            parser.Permitted.Variables.Add("@CurrentUserId");            
            
            var rc = parser.CriteriaToSafeSql("exists(select IssueId from Issues i2 where AssignedToUser = @CurrentUserId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues i2 where AssignedToUser = @CurrentUserId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void TableAliasExplicit()
        {
            var parser = new RobertsSQLParser.QueryParser();
            parser.Permitted.PermittedColumns.Add(new Regex(".*"));
            parser.Permitted.Variables.Add("@CurrentUserId");           
            
            var rc = parser.CriteriaToSafeSql("exists(select IssueId from Issues as i2 where AssignedToUser = @CurrentUserId)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from Issues as i2 where AssignedToUser = @CurrentUserId)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SubquerySource()
        {
            var rc = p.CriteriaToSafeSql("exists(select IssueId from (select i from o) as i2)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId from (select i from o) as i2)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void ExpressionImplicitAlias()
        {
            var rc = p.CriteriaToSafeSql("exists(select IssueId * 2 IssueId2 from Issues)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("exists(select IssueId * 2 IssueId2 from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }


        [TestMethod]
        public void SubQuery()
        {
            var rc = p.CriteriaToSafeSql("1 = (select IssueId * 2 IssueId2 from Issues)");
             Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select IssueId * 2 IssueId2 from Issues)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
        
        [TestMethod]
        public void TopNQuery()
        {
            var rc = p.CriteriaToSafeSql("Issues.ResolutionCode = 'Customer - More Information' and Issues.StatusCode = 'Open' and (select count(*) from IssueHistory as ih1 where ih1.OldAssignedToUser = ih1.NewAssignedToUser and ih1.HistoryId = (select top 1 HistoryId from IssueHistory as ih2 where ih2.IssueId = Issues.IssueId order by ih2.IssueId, ih2.HistoryId desc)) = 1");
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual("Issues.ResolutionCode = 'Customer - More Information' and Issues.StatusCode = 'Open' and (select count(*) from IssueHistory as ih1 where ih1.OldAssignedToUser = ih1.NewAssignedToUser and ih1.HistoryId = (select top 1 HistoryId from IssueHistory as ih2 where ih2.IssueId = Issues.IssueId order by ih2.IssueId, ih2.HistoryId desc)) = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SubQueryNoFrom()
        {
            var rc = p.CriteriaToSafeSql("1 = (select 2)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select 2)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SubQueryForDate()
        {
            var rc = p.CriteriaToSafeSql("1 = (select case when exists(select * from RMTrackSite where StoreTimesAsUTC = 1) then getutcdate() else getdate() end)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = (select case when exists(select * from RMTrackSite where StoreTimesAsUTC = 1) then getutcdate() else getdate() end)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
    }
}

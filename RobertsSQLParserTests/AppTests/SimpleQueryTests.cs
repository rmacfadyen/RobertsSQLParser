using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.AppTests
{
    [TestClass]
    public class SimpleQueryTests
    {

        [TestMethod]
        public void T1()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            p.Permitted.Variables.Add("@Guid");
            
            var Query = "exists(select [FileName], [FileSize], [IsPersist] from [AjaxUploaderTempFiles] where FileGuid = @Guid)";
            
            var rc = p.CriteriaToSafeSql(Query);
            Assert.AreEqual(Query, rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void T2()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            p.Permitted.Variables.Add("@UserId");
            
            var Query = "exists(select UserTypeCode from Users inner join RMTrackUserTypes on RMTrackUserTypes.UserTypeId = Users.UserTypeId where Users.UserId = @UserId)";
            
            var rc = p.CriteriaToSafeSql(Query);
            Assert.AreEqual(Query, rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void T3()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
            p.Permitted.Variables.Add("@UserId");
            p.Permitted.Variables.Add("@SessionId");
            
            var Query = "exists(select * from RMTrackUserSessions inner join Users on Users.UserId = @UserId where RMTrackUserSessions.UserId = @UserId and RMTrackUserSessions.SessionId = @SessionId and Users.Active = 1)";
            
            var rc = p.CriteriaToSafeSql(Query);
            Assert.AreEqual(Query, rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
        /*
                [TestMethod]
                public void T1()
                {
                    RobertsSQLParser.CriteriaParser p = new RobertsSQLParser.CriteriaParser();

                    string Query = "SELECT [FileName], [FileSize], [IsPersist] FROM [AjaxUploaderTempFiles] WHERE FileGuid = @Guid";

                    var rc = p.ToSafeSql(Query);
                    Assert.IsTrue(rc.IsSafe);
                    Assert.AreEqual(null, rc.ErrorDetails);
                    Assert.AreEqual(Query, rc.SafeSql);
                    Assert.AreEqual(null, rc.ErrorDetails);
                }

                [TestMethod]
                public void T1()
                {
                    RobertsSQLParser.CriteriaParser p = new RobertsSQLParser.CriteriaParser();

                    string Query = "SELECT [FileName], [FileSize], [IsPersist] FROM [AjaxUploaderTempFiles] WHERE FileGuid = @Guid";

                    var rc = p.ToSafeSql(Query);
                    Assert.IsTrue(rc.IsSafe);
                    Assert.AreEqual(null, rc.ErrorDetails);
                    Assert.AreEqual(Query, rc.SafeSql);
                    Assert.AreEqual(null, rc.ErrorDetails);
                }

                [TestMethod]
                public void T1()
                {
                    RobertsSQLParser.CriteriaParser p = new RobertsSQLParser.CriteriaParser();

                    string Query = "SELECT [FileName], [FileSize], [IsPersist] FROM [AjaxUploaderTempFiles] WHERE FileGuid = @Guid";

                    var rc = p.ToSafeSql(Query);
                    Assert.IsTrue(rc.IsSafe);
                    Assert.AreEqual(null, rc.ErrorDetails);
                    Assert.AreEqual(Query, rc.SafeSql);
                    Assert.AreEqual(null, rc.ErrorDetails);
                }

                [TestMethod]
                public void T1()
                {
                    RobertsSQLParser.CriteriaParser p = new RobertsSQLParser.CriteriaParser();

                    string Query = "SELECT [FileName], [FileSize], [IsPersist] FROM [AjaxUploaderTempFiles] WHERE FileGuid = @Guid";

                    var rc = p.ToSafeSql(Query);
                    Assert.IsTrue(rc.IsSafe);
                    Assert.AreEqual(null, rc.ErrorDetails);
                    Assert.AreEqual(Query, rc.SafeSql);
                    Assert.AreEqual(null, rc.ErrorDetails);
                }

                [TestMethod]
                public void T1()
                {
                    RobertsSQLParser.CriteriaParser p = new RobertsSQLParser.CriteriaParser();

                    string Query = "SELECT [FileName], [FileSize], [IsPersist] FROM [AjaxUploaderTempFiles] WHERE FileGuid = @Guid";

                    var rc = p.ToSafeSql(Query);
                    Assert.IsTrue(rc.IsSafe);
                    Assert.AreEqual(null, rc.ErrorDetails);
                    Assert.AreEqual(Query, rc.SafeSql);
                    Assert.AreEqual(null, rc.ErrorDetails);
                }

                [TestMethod]
                public void T1()
                {
                    RobertsSQLParser.CriteriaParser p = new RobertsSQLParser.CriteriaParser();

                    string Query = "SELECT [FileName], [FileSize], [IsPersist] FROM [AjaxUploaderTempFiles] WHERE FileGuid = @Guid";

                    var rc = p.ToSafeSql(Query);
                    Assert.IsTrue(rc.IsSafe);
                    Assert.AreEqual(null, rc.ErrorDetails);
                    Assert.AreEqual(Query, rc.SafeSql);
                    Assert.AreEqual(null, rc.ErrorDetails);
                }
        */
    }
}

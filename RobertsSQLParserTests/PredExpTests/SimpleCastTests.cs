using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.PredExpTests
{
    [TestClass]
    public class SimpleCastTests
    {
        RobertsSQLParser.QueryParser p;

        [TestInitialize]
        public void Initialize()
        {
            p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));
        }

        [TestMethod]
        public void SimpleCastAsBigint()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as bigint)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as bigint)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsNumeric()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as numeric)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as numeric)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsBit()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as bit)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as bit)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsSmallint()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as smallint)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as smallint)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsDecimal()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as decimal)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as decimal)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsSmallmoney()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as smallmoney)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as smallmoney)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsInt()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as int)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as int)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsTinyint()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as tinyint)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as tinyint)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsMoney()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as money)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as money)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsFloat()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as float)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as float)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsReal()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as real)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as real)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsDate()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as date)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as date)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsDatetimeoffset()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as datetimeoffset)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as datetimeoffset)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsDatetime2()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as datetime2)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as datetime2)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsSmalldatetime()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as smalldatetime)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as smalldatetime)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsDatetime()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as datetime)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as datetime)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsTime()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as time)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as time)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsChar()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as char)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as char)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsVarchar()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as varchar)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as varchar)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsText()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as text)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as text)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsNchar()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as nchar)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as nchar)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsNvarchar()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as nvarchar)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as nvarchar)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsNtext()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as ntext)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as ntext)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsBinary()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as binary)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as binary)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsVarbinary()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as varbinary)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as varbinary)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsImage()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as image)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as image)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsTimestamp()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as timestamp)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as timestamp)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsUniqueidentifier()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as uniqueidentifier)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as uniqueidentifier)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsWithLength()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as bigint(12))");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as bigint(12))", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }

        [TestMethod]
        public void SimpleCastAsWithLengthAndPrecision()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as bigint(12, 4))");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("IssueId = cast(IssueId as bigint(12, 4))", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
        }
    }
}

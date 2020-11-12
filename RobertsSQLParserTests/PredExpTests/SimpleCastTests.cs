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
            Assert.AreEqual("IssueId = cast(IssueId as bigint)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsNumeric()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as numeric)");
            Assert.AreEqual("IssueId = cast(IssueId as numeric)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsBit()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as bit)");
            Assert.AreEqual("IssueId = cast(IssueId as bit)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsSmallint()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as smallint)");
            Assert.AreEqual("IssueId = cast(IssueId as smallint)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsDecimal()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as decimal)");
            Assert.AreEqual("IssueId = cast(IssueId as decimal)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsSmallmoney()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as smallmoney)");
            Assert.AreEqual("IssueId = cast(IssueId as smallmoney)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsInt()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as int)");
            Assert.AreEqual("IssueId = cast(IssueId as int)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsTinyint()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as tinyint)");
            Assert.AreEqual("IssueId = cast(IssueId as tinyint)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsMoney()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as money)");
            Assert.AreEqual("IssueId = cast(IssueId as money)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsFloat()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as float)");
            Assert.AreEqual("IssueId = cast(IssueId as float)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsReal()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as real)");
            Assert.AreEqual("IssueId = cast(IssueId as real)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsDate()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as date)");
            Assert.AreEqual("IssueId = cast(IssueId as date)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsDatetimeoffset()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as datetimeoffset)");
            Assert.AreEqual("IssueId = cast(IssueId as datetimeoffset)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsDatetime2()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as datetime2)");
            Assert.AreEqual("IssueId = cast(IssueId as datetime2)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsSmalldatetime()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as smalldatetime)");
            Assert.AreEqual("IssueId = cast(IssueId as smalldatetime)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsDatetime()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as datetime)");
            Assert.AreEqual("IssueId = cast(IssueId as datetime)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsTime()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as time)");
            Assert.AreEqual("IssueId = cast(IssueId as time)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsChar()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as char)");
            Assert.AreEqual("IssueId = cast(IssueId as char)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsVarchar()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as varchar)");
            Assert.AreEqual("IssueId = cast(IssueId as varchar)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsText()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as text)");
            Assert.AreEqual("IssueId = cast(IssueId as text)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsNchar()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as nchar)");
            Assert.AreEqual("IssueId = cast(IssueId as nchar)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsNvarchar()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as nvarchar)");
            Assert.AreEqual("IssueId = cast(IssueId as nvarchar)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsNtext()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as ntext)");
            Assert.AreEqual("IssueId = cast(IssueId as ntext)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsBinary()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as binary)");
            Assert.AreEqual("IssueId = cast(IssueId as binary)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsVarbinary()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as varbinary)");
            Assert.AreEqual("IssueId = cast(IssueId as varbinary)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsImage()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as image)");
            Assert.AreEqual("IssueId = cast(IssueId as image)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsTimestamp()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as timestamp)");
            Assert.AreEqual("IssueId = cast(IssueId as timestamp)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsUniqueidentifier()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as uniqueidentifier)");
            Assert.AreEqual("IssueId = cast(IssueId as uniqueidentifier)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsWithLength()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as bigint(12))");
            Assert.AreEqual("IssueId = cast(IssueId as bigint(12))", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void SimpleCastAsWithLengthAndPrecision()
        {
            var rc = p.CriteriaToSafeSql("IssueId = cast(IssueId as bigint(12, 4))");
            Assert.AreEqual("IssueId = cast(IssueId as bigint(12, 4))", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
    }
}

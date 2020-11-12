using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobertsSQLParserTests.RestrictedItemsTests
{
    [TestClass]
    public class TableAndColumns
    {
        [TestMethod]
        public void ExplicitlyAllowedTable()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"dbo\.SomeTable\.SomeColumn"));
            var rc = p.CriteriaToSafeSql("dbo.SomeTable.SomeColumn = 1");
            Assert.AreEqual("dbo.SomeTable.SomeColumn = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void ExplicitlyDatabaseAllowedTable()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"mydb\.dbo\.SomeTable\.SomeColumn"));
            var rc = p.CriteriaToSafeSql("mydb.dbo.SomeTable.SomeColumn = 1");
            Assert.AreEqual("mydb.dbo.SomeTable.SomeColumn = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void ExplicitlyAllowedTableExtraWhiteSpaces()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"dbo\.SomeTable\.SomeColumn"));
            var rc = p.CriteriaToSafeSql("dbo  .  SomeTable  .  SomeColumn = 1");
            Assert.AreEqual("dbo.SomeTable.SomeColumn = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }


        [TestMethod]
        public void ColumnWildcard()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"dbo\.SomeTable\..*"));
            var rc = p.CriteriaToSafeSql("dbo.SomeTable.SomeColumn = 1");
            Assert.AreEqual("dbo.SomeTable.SomeColumn = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
        [TestMethod]
        public void SchemaWildcardColumnWildcard()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"((.*).)?SomeTable\..*"));
            var rc = p.CriteriaToSafeSql("dbo.SomeTable.SomeColumn = 1");
            Assert.AreEqual("dbo.SomeTable.SomeColumn = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }
        [TestMethod]
        public void DboSchemaOrNoSchemaUsingDbo()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"(dbo\.)?SomeTable\..*"));
            var rc = p.CriteriaToSafeSql("dbo.SomeTable.SomeColumn = 1");
            Assert.AreEqual("dbo.SomeTable.SomeColumn = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }

        [TestMethod]
        public void DboSchemaOrNoSchemaNotUsingDbo()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"(dbo\.)?SomeTable\..*"));
            var rc = p.CriteriaToSafeSql("SomeTable.SomeColumn = 1");
            Assert.AreEqual("SomeTable.SomeColumn = 1", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.IsTrue(rc.IsSafe);
        }


        [TestMethod]
        public void NotAllowedSchemaTableColumn()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"dbo\.SomeTable\.SomeColumn"));
            var rc = p.CriteriaToSafeSql("dbo.NotSomeTable.SomeColumn = 1");
            Assert.AreEqual(null, rc.SafeSql);
            Assert.AreEqual("Column dbo.NotSomeTable.SomeColumn is not in the list of permitted columns", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }

        [TestMethod]
        public void NotAllowedTableColumn()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"dbo\.SomeTable\.SomeColumn"));
            var rc = p.CriteriaToSafeSql("NotSomeTable.SomeColumn = 1");
            Assert.AreEqual(null, rc.SafeSql);
            Assert.AreEqual("Column NotSomeTable.SomeColumn is not in the list of permitted columns", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }
        [TestMethod]
        public void NotAllowedColumn()
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(@"dbo\.SomeTable\.SomeColumn"));
            var rc = p.CriteriaToSafeSql("SomeColumn = 1");
            Assert.AreEqual(null, rc.SafeSql);
            Assert.AreEqual("Column SomeColumn is not in the list of permitted columns", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }
    }
}

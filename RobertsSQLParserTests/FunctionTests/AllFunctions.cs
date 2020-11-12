using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RobertsSQLParserTests.FunctionTests
{
    [TestClass]
    public class AllFunctions
    {
        private static void ZeroArgTest(string Function)
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = " + Function + "()");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = " + Function + "()", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(1)");
            Assert.AreEqual("Function " + Function + " requires 0 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2, 3)");
            Assert.AreEqual("Function " + Function + " requires 0 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }

        private static void OneArgTest(string Function)
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = " + Function + "(2)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = " + Function + "(2)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);

            rc = p.CriteriaToSafeSql("1 = " + Function + "()");
            Assert.AreEqual("Function " + Function + " requires 1 arguments", rc.ErrorDetails); 
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2, 3)");
            Assert.AreEqual("Function " + Function + " requires 1 arguments", rc.ErrorDetails); 
            Assert.IsFalse(rc.IsSafe);
        }

        private static void TwoArgTest(string Function)
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = " + Function + "(2, 3)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = " + Function + "(2, 3)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);

            rc = p.CriteriaToSafeSql("1 = " + Function + "()");
            Assert.AreEqual("Function " + Function + " requires 2 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2)");
            Assert.AreEqual("Function " + Function + " requires 2 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2,3,4)");
            Assert.AreEqual("Function " + Function + " requires 2 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }

        private static void ThreeArgTest(string Function)
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = " + Function + "(2, 3, 4)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = " + Function + "(2, 3, 4)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);

            rc = p.CriteriaToSafeSql("1 = " + Function + "()");
            Assert.AreEqual("Function " + Function + " requires 3 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2)");
            Assert.AreEqual("Function " + Function + " requires 3 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2,3)");
            Assert.AreEqual("Function " + Function + " requires 3 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2,3,4,5)");
            Assert.AreEqual("Function " + Function + " requires 3 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }

        private static void FourArgTest(string Function)
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = " + Function + "(2, 3, 4, 5)");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = " + Function + "(2, 3, 4, 5)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);

            rc = p.CriteriaToSafeSql("1 = " + Function + "()");
            Assert.AreEqual("Function " + Function + " requires 4 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2)");
            Assert.AreEqual("Function " + Function + " requires 4 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2, 3)");
            Assert.AreEqual("Function " + Function + " requires 4 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2, 3, 4)");
            Assert.AreEqual("Function " + Function + " requires 4 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + Function + "(2, 3, 4, 5, 6)");
            Assert.AreEqual("Function " + Function + " requires 4 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }

        private static void AggregateTest(string AggregateName)
        {
            var p = new RobertsSQLParser.QueryParser();
            p.Permitted.PermittedColumns.Add(new Regex(".*"));

            var rc = p.CriteriaToSafeSql("1 = (select " + AggregateName + "(Column) from Table)");
            Assert.AreEqual(null, rc.ErrorDetails); 
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual("1 = (select " + AggregateName + "(Column) from Table)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
            
            rc = p.CriteriaToSafeSql("1 = " + AggregateName + "(1) ");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = " + AggregateName + "(1)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);
           
            rc = p.CriteriaToSafeSql("1 = " + AggregateName + "(distinct 1) ");
            Assert.IsTrue(rc.IsSafe);
            Assert.AreEqual(null, rc.ErrorDetails);
            Assert.AreEqual("1 = " + AggregateName + "(distinct 1)", rc.SafeSql);
            Assert.AreEqual(null, rc.ErrorDetails);

            rc = p.CriteriaToSafeSql("1 = " + AggregateName + "( )");
            Assert.AreEqual("Function " + AggregateName + " requires 1 or 2 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);

            rc = p.CriteriaToSafeSql("1 = " + AggregateName + "(distinct 2, 3)");
            Assert.AreEqual("Function " + AggregateName + " requires 1 or 2 arguments", rc.ErrorDetails);
            Assert.IsFalse(rc.IsSafe);
        }



        [TestMethod]
        public void TestAllFunctions()
        {
            foreach (var Function in FunctionArgs)
            {
                switch (Function.Value)
                {
                    case 0:
                        ZeroArgTest(Function.Key);
                        break;
                    case 1:
                        OneArgTest(Function.Key);
                        break;
                    case 2:
                        TwoArgTest(Function.Key);
                        break;
                    case 3:
                        ThreeArgTest(Function.Key);
                        break;
                    case 4:
                        FourArgTest(Function.Key);
                        break;
                    default:
                        Assert.Fail("Unknown number of arguments");
                        break;
                }
            }
        }


        [TestMethod]
        public void TestAllAggregates()
        {
            AggregateTest("count");
            AggregateTest("avg");
            AggregateTest("min");
            AggregateTest("max");
            AggregateTest("stdev");
            AggregateTest("stdevp");
            AggregateTest("sum");
            AggregateTest("var");
            AggregateTest("varp");
        }

        private static Dictionary<string, int> FunctionArgs = new Dictionary<string, int> {
            { "getdate", 0 }, 
            { "getutcdate", 0 },
            { "pi", 0 },

            { "abs", 1 }, 
            { "acos", 1 }, 
            { "ascii", 1 }, 
            { "asin", 1 }, 
            { "atan", 1 }, 
            { "atn2", 1 }, 
            { "ceiling", 1 }, 
            { "char", 1 }, 
            { "cos", 1 }, 
            { "cot", 1 }, 
            { "day", 1 }, 
            { "degrees", 1 }, 
            { "exp", 1 }, 
            { "floor", 1 }, 
            { "isdate", 1 }, 
            { "isnumeric", 1 }, 
            { "len", 1 }, 
            { "log", 1 }, 
            { "log10", 1 }, 
            { "lower", 1 }, 
            { "ltrim", 1 }, 
            { "month", 1 }, 
            { "nchar", 1 }, 
            { "radians", 1 }, 
            { "reverse", 1 }, 
            { "rtrim", 1 }, 
            { "soundex", 1 }, 
            { "sign", 1 }, 
            { "space", 1 }, 
            { "sqrt", 1 }, 
            { "square", 1 }, 
            { "tan", 1 }, 
            { "unicode", 1 }, 
            { "upper", 1 }, 
            { "year", 1 }, 

            { "power", 2 }, 
            { "isnull", 2 }, 
            { "nullif", 2 },        
            { "left", 2 }, 
            { "difference", 2 }, 
            { "replicate", 2 }, 
            { "right", 2 },   

            { "replace", 3 },
            { "substring", 3 },

            { "stuff", 4 },
        };
    }
}

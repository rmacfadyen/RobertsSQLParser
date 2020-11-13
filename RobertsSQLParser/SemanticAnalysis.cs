using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace RobertsSQLParser
{

    internal class SemanticAnalysis : SqlBaseVisitor<bool>
    {
        public readonly IList<string> Errors = new List<string>();
        
        private readonly IDictionary<string, int> _userDefinedFunctions;
        private readonly ICollection<string> _permittedVariables;
        private readonly IList<Regex> _permittedSchemasElements;
        

        public SemanticAnalysis(IDictionary<string, int> UserDefinedFunctions, ICollection<string> Variables, IList<Regex> PermittedSchemasElements)
        {
            _userDefinedFunctions = UserDefinedFunctions ?? throw new ArgumentNullException(nameof(UserDefinedFunctions));
            _permittedVariables = Variables ?? throw new ArgumentNullException(nameof(Variables));
            _permittedSchemasElements = PermittedSchemasElements ?? throw new ArgumentNullException(nameof(PermittedSchemasElements));
        }

 
        public override bool VisitVariableName([Antlr4.Runtime.Misc.NotNull] SqlParser.VariableNameContext context)
        {
            var name = context.children.First().GetText();
            if (_permittedVariables == null || !_permittedVariables.Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                Errors.Add($"Unknown variable: {name}");
                return true;
            }

            return base.VisitVariableName(context);
        }

        public override bool VisitQualified_column_name([NotNull] SqlParser.Qualified_column_nameContext context)
        {

            string ColumnName = "";
            foreach (var child in context.children)
            {
                if (child is ITerminalNode n && n.Symbol.Type == SqlLexer.DOT)
                {
                    ColumnName += child.GetText();
                }
                else if (child is SqlParser.Database_nameContext
                    || child is SqlParser.Schema_nameContext 
                    || child is SqlParser.Table_nameContext 
                    || child is SqlParser.Column_nameContext)
                {
                    ColumnName += child.GetText();
                }
            }
            if (_permittedSchemasElements != null)
            {
                bool IsValid = false;

                foreach (var PermittedElement in _permittedSchemasElements)
                {
                    if (PermittedElement.IsMatch(ColumnName))
                    {
                        IsValid = true;
                        break;
                    }
                }

                if (!IsValid)
                {
                    Errors.Add($"Column {ColumnName} is not in the list of permitted columns");
                }
            }

            return base.VisitQualified_column_name(context);
        }



        public override bool VisitFunctionCall([Antlr4.Runtime.Misc.NotNull] SqlParser.FunctionCallContext context)
        {
            if (IsFunctionNameValid(context))
            {
                if (!IsFunctionArgumentCountValid(context))
                {
                    return true;
                }
            }

            return false;
        }


        private bool IsFunctionNameValid(SqlParser.FunctionCallContext context)
        {
            var FunctionName = GetFunctionName(context);

            if (!(_userDefinedFunctions.ContainsKey(FunctionName)
                  || FunctionConstants.FunctionArgs.ContainsKey(FunctionName)
                  || FunctionConstants.AgregateNames.Contains(FunctionName) 
                  || FunctionConstants.SpecialFunctions.ContainsKey(FunctionName)))
            {
                Errors.Add($"Unknown function: {FunctionName}");
                return false;
            }

            return true;
        }

   
        private bool IsFunctionArgumentCountValid(SqlParser.FunctionCallContext context)
        {
            //
            // Get the name of the function
            //
            var FunctionName = GetFunctionName(context);

            //
            // Count the number of arguements. Each argument is an Expr or a * so
            // just count those.
            //
            int NumArguments = 0;
            foreach (var c in context.children)
            {
                if (c is SqlParser.ExprContext
                    || c is ITerminalNode && (c as ITerminalNode).Symbol.Type == SqlParser.STAR)
                {
                    NumArguments += 1;
                }
            }    

            //
            // Special functions have a variable number of arguments that need
            // their own handling
            //
            if (FunctionConstants.SpecialFunctions.ContainsKey(FunctionName))
            {
                if (!ValidateComplexFunction(FunctionName, NumArguments, FunctionConstants.SpecialFunctions[FunctionName]))
                {
                    return false;
                }

                //
                // The first argument for dateadd should be a keyword (dd, mm, etc)
                //
                if (string.Compare(FunctionName, "dateadd", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (!IsDateAddFirstArgumentValid(context))
                    {
                        Errors.Add("The dateadd function's first parameter is invalid");
                        return false;
                    }
                }

                //
                // Success
                //
                return true;
            }

            //
            // Normal functions have a set number of arguments 
            //
            if (FunctionConstants.FunctionArgs.ContainsKey(FunctionName))
            {
                if (FunctionConstants.FunctionArgs[FunctionName] != NumArguments)
                {
                    Errors.Add($"Function {FunctionName} requires {FunctionConstants.FunctionArgs[FunctionName]} arguments");
                    return false;
                }

                //
                // Success
                //
                return true;
            }

            //
            // Agregates have 1 argument (no commas)
            //
            if (FunctionConstants.AgregateNames.Contains(FunctionName))
            {
                if (NumArguments != 1)
                {
                    Errors.Add($"Function {FunctionName} requires 1 arguments");
                    return false;
                }

                return true;
            }

            //
            // Must be a user defined function
            //
            if (_userDefinedFunctions[FunctionName] != NumArguments)
            {
                Errors.Add($"Function {FunctionName} requires {_userDefinedFunctions[FunctionName]} arguments but called with {NumArguments}");
                return false;
            }

            return true;
        }
    


        private string GetFunctionName(SqlParser.FunctionCallContext context)
        {
            var FunctionName = "";
            foreach (var child in context.children)
            {
                //
                // Stop on the open parenthesis
                //
                if (child is ITerminalNode n && n.Symbol.Type == SqlLexer.OPEN_PAR)
                {
                    break;
                }

                FunctionName += child.GetText();
            }

            return FunctionName;
        }


        private static readonly IList<string> ValidOps = new List<string>
        {
            "year", "yyyy", "yy",
            "quarter", "qq", "q",
            "month", "mm", "m",
            "dayofyear", "dy", "y",
            "day", "dd", "d",
            "week", "ww", "wk",
            "weekday", "dw", "w",
            "hour", "hh",
            "minute", "mi", "n",
            "second", "ss", "s",
            "millisecond", "ms",
            "microsecond", "mcs",
            "nanosecond", "ns"
        };

        private bool IsDateAddFirstArgumentValid(SqlParser.FunctionCallContext context)
        {
            if (context.children.Count >= 2)
            {
                if (context.children[2].ChildCount >= 1)
                {
                    var c20 = context.children[2].GetChild(0);
                    if (c20.ChildCount == 1)
                    {
                        var op = c20.GetText();
                        if (ValidOps.Contains(op, StringComparer.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        private bool ValidateComplexFunction(string FunctionName, int ActualArgCount, (bool Unlimited, int[] Args) ArgLimits)
        {
            if (ArgLimits.Unlimited || ArgLimits.Args == null)
            {
                if (ActualArgCount == 0)
                {
                    Errors.Add($"Function {FunctionName} requires at least one argument");
                    return false;
                }
            }
            else
            {
                var Valid = (from ArgCount in ArgLimits.Args where ArgCount == ActualArgCount select 1).Any();
                if (!Valid)
                {
                    if (ArgLimits.Args.Length == 1)
                    {
                        Errors.Add($"Function {FunctionName} requires {ArgLimits.Args.First()} arguments");
                    }
                    else
                    {
                        var Last = ArgLimits.Args.Reverse().Take(1).Count();
                        var Leading = ArgLimits.Args.Take(ArgLimits.Args.Length - 1);
                        Errors.Add(
                            $"Function {FunctionName} requires {string.Join(", ", from n in Leading select n.ToString())} or {Last} arguments");
                    }

                    return false;
                }
            }

            return true;
        }
    }
}

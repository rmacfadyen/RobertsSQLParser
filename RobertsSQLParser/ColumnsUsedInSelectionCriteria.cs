using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using System.Linq;

namespace RobertsSQLParser
{

    internal static class ColumnsUsedInSelectionCriteria
    {
        public static IList<string> GetColumnsUsed(IParseTree context)
        {
            var Visitor = new WhereColumnExpressionVistor();
            context.Accept(Visitor);
            return Visitor.Columns;
        }

        class WhereColumnExpressionVistor : SqlBaseVisitor<bool>
        {
            public IList<string> Columns { get;  } = new List<string>();

            //
            // Column name
            //
            public override bool VisitColumn_name([Antlr4.Runtime.Misc.NotNull] SqlParser.Column_nameContext context)
            {
                //
                // Check each parent/grandparent/great.. to see where
                // this column was used (it's either going to be
                // a WhereNode, a SelectNode, or at the very top level
                //
                var ChildOfWhere = true;
                for (var Parent = context.Parent; Parent != null; Parent = Parent.Parent)
                {
                    if (Parent.RuleIndex == SqlParser.RULE_where_clause)
                    {
                        //
                        // A column in the actual where clause
                        //
                        break;
                    }

                    if (Parent.RuleIndex == SqlParser.RULE_select_stmt)
                    {
                        //
                        // A column in the select list itself (and not 
                        // in the where clause
                        //
                        ChildOfWhere = false;

                        //
                        // Done looking
                        //
                        break;
                    }
                }

                if (ChildOfWhere)
                {
                    Columns.Add(context.children.First().GetText());
                }

                return false;
            }
        }
    }
}
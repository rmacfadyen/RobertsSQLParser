using System;
using System.Collections.Generic;

namespace RobertsSQLParser
{


    internal static class FunctionConstants
    {
        public static readonly HashSet<string> AgregateNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "count",
            "avg",
            "min",
            "max",
            "stdev",
            "stdevp",
            "sum",
            "var",
            "varp"
        };


        public static readonly IDictionary<string, (bool Unlimited, int[] Args)> SpecialFunctions
            = new Dictionary<string, (bool Unlimited, int[] Args)>(StringComparer.OrdinalIgnoreCase)
            {
                {"dateadd", (false, new[] {3})},

                {"datediff", (false, new[] {3})},
                {"cast", (false, new[] {3})},

                {"datename", (false, new[] {2})},
                {"datepart", (false, new[] {2})},
                {"patindex", (false, new[] {2})},

                {"str", (false, new[] {1, 2, 3})},

                {"charindex", (false, new[] {2, 3})},
                {"convert", (false, new[] {2, 3})},
                {"round", (false, new[] {2, 3})},

                {"quotename", (false, new[] {1, 2})},

                {"rand", (false, new[] {0, 1})},

                {"coalesce", (true, null)}
            };
    


        public static readonly Dictionary<string, int> FunctionArgs = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase) {
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
using System;
using System.Collections.Generic;
using LoliLang.Lexy.ParsingRules;

namespace LoliLang.Lexy
{
    public static class LexyLinq
    {
        public static IEnumerable<Token> TryToLookAt(this IEnumerable<IParsingRule> rules, string expression)
        {
            var lexy = new Lexy(rules);
            return lexy.LookAt(expression);
        }
    }
}
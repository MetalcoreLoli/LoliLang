using System.Collections.Generic;
using LoliLang.Spell.Dryad;
using LoliLang.Spell.Lexy.ParsingRules;

namespace LoliLang.Spell.Lexy
{
    public static class LexyLinq
    {
        public static IEnumerable<Token> TryToLookAt(this IEnumerable<IParsingRule> rules, string expression)
        {
            var lexy = new Spell.Lexy.Lexy(rules, new Daphnaie());
            return lexy.LookAt(expression);
        }
    }
}
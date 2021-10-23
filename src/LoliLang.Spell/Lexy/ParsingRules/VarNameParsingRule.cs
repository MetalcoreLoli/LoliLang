using System;
using System.Collections.Generic;

namespace LoliLang.Spell.Lexy.ParsingRules
{
    internal class VarNameParsingRule : IParsingRule
    {
        public Token? TryOn(string symbol, string context)
        {
            if (symbol == "=" || symbol == " ") return null; 
            var tail = symbol;
            for (int i = 1; i < context.Length; i++)
            {
                if (context[i] == '=') break;
                tail += context[i];
                if (LexyParsingMagick.ReservedWord.Contains(tail.Trim()))
                    return null;
            }

            tail = tail.Trim();
            if (LexyParsingMagick.ReservedWord.Contains(tail))
                return null;

            return new Token(tail, Token.Forma.Var);
        }
    }
}
using System.Linq;

namespace LoliLang.Spell.Lexy.ParsingRules
{
    internal class EqParingRule : BinaryOperationParsingRule
    {
        public EqParingRule() : base("==", Token.Forma.Eq)
        {
        }

        public override Token? TryOn(char symbol, string context)
        {
            string word = symbol.ToString();
            for (int i = 1; i < context.Length; i++)
            {
                word += context[i];
                (_, string result) = LexyParsingMagick.ParseWord(word, context);
                if (result == _value)
                    return new Token(result, Token.Forma.Eq);
            }
            return null;
        }
    }
}
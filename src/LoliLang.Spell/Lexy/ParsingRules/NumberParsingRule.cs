namespace LoliLang.Spell.Lexy.ParsingRules
{
    internal class NumberParsingRule : IParsingRule
    {
        public Token? TryOn(char symbol, string context)
        {
            var number = symbol.ToString();
            if (!int.TryParse(number, out _)) return default;
            for (int i = 1; i < context.Length; i++)
            {
                string tailOfNumber = context[i].ToString();
                if (!int.TryParse(tailOfNumber, out _))
                    break;
                number += tailOfNumber;
            }
            return new Token(number, Token.Forma.Number);
        }
    }
}
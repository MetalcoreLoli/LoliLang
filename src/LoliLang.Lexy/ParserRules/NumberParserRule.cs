namespace LoliLang.Lexy.ParserRules
{
    internal class NumberParserRule : IParserRule
    {
        public Token? TryOn(char symbol, string context)
        {
            //    string number = num.ToString();
            //    int j = i + 1;
            //    for (; j < expression.Length; j++)
            //    {
            //        string tailOfNumber = expression[j].ToString();
            //        if (!int.TryParse(tailOfNumber, out _))
            //            break;
            //        number += tailOfNumber;
            //    }
            //    i = j - 1;
            //    tokens.Add(new Token(number, Token.Forma.Number));
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
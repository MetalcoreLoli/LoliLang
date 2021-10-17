using System;
using System.Collections.Generic;

namespace LoliLang.Lexy
{
    public class Lexy
    {
        private IEnumerable<IParserRule> _rules;
        public IEnumerable<string> AnswersOn(string s)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Token> LookAt(string expression)
        {
            var tokens = new List<Token>();

            for (var i = 0; i < expression.Length; i++)
            {
                var symbol = expression[i];
                if (symbol is '+')
                    tokens.Add(new Token(symbol.ToString(), Token.Forma.Plus));
                else if (int.TryParse(symbol.ToString(), out int num))
                {
                    string number = num.ToString();
                    int j = i + 1;
                    for (; j < expression.Length; j++)
                    {
                        string tailOfNumber = expression[j].ToString();
                        if (!int.TryParse(tailOfNumber, out _))
                            break;
                        number += tailOfNumber;
                    }
                    i = j - 1;
                    tokens.Add(new Token(number, Token.Forma.Number));
                }
            }
            return tokens;
        }
    }
}
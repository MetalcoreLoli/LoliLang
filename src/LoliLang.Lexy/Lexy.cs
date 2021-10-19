using System;
using System.Collections.Generic;
using System.Linq;
using LoliLang.Lexy.ParsingRules;

namespace LoliLang.Lexy
{
    public class Lexy
    {
        private IEnumerable<IParsingRule> _rules;

        public Lexy() : this (LexyParsingMagick.RulesBook)
        {
        }

        public Lexy(IEnumerable<IParsingRule> rules)
        {
            _rules = rules;
        }

        public IEnumerable<string> AnswersOn(string s)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Token> LookAt(string expression)
        {
            var tokens = new List<Token>();

            while (expression.Length > 0)
            {
                var symbol = expression.First();
                var sub = expression.Substring(expression.IndexOf(symbol), expression.Length);
                var token = _rules.TransformingSpellOn(symbol, sub, out _);
                var amountOfSkipChars = 1;
                if (token.HasValue)
                {
                    tokens.Add(token.Value);
                    amountOfSkipChars = token.Value.Value.Length;
                }
                
                expression = sub.Skip(amountOfSkipChars).Aggregate("", (s, acc) => s + acc);
            }
            return tokens;
        }
    }
   public static class LexyParsingMagick
   {
       public static readonly List<IParsingRule> RulesBook = new()
       {
           new NumberParsingRule(), 
           new PlusParsingRule(),
           new SubParsingRule(), 
           new MulParsingRule(),
           new DivParsingRule(), 
       };
       public static Token? TransformingSpellOn (
           this IEnumerable<IParsingRule> rules,
           char symbol,
           string expression,
           out IEnumerable<string> errors)
       {
           var errs = new List<string>();
           Token? result = default;
           foreach (var rule in rules)
           {
               result = rule.TryOn(symbol, expression);
               if (result.HasValue)
                   break;
               errs.Add($"rule {rule.GetType().Name} does not work on {symbol}");
           }
           errors = errs;
           return result;
       }

       public static IEnumerable<Token> EyeOfTruth(this IEnumerable<Token> line)
       {
           throw new NotImplementedException();
       }

   }
}
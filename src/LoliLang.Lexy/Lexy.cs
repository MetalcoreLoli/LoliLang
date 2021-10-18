﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LoliLang.Lexy.ParserRules;

namespace LoliLang.Lexy
{
    public class Lexy
    {
        private IEnumerable<IParserRule> _rules;

        public Lexy() : this(
            new List<IParserRule>()
            {
                new NumberParserRule(), new PlusParserRule()
            })
        {
        }

        public Lexy(IEnumerable<IParserRule> rules)
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
                var token = _rules.TransformingSpellOn(symbol, sub, out IEnumerable<string> errors);

                if (!token.HasValue)
                    throw new InvalidDataException(errors.First());
                tokens.Add(token.Value);

                expression = sub.Skip(token.Value.Value.Length).Aggregate("", (s, acc) => s + acc);
            }
            return tokens;
        }
    }
    
   internal static class LexyParserMagick
   {
       public static Token? TransformingSpellOn(this IEnumerable<IParserRule> rules, char symbol, string expression, out IEnumerable<string> errors)
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
   }
}
using System;
using System.Collections.Generic;
using System.Linq;
using LoliLang.Spell.Dryad.Mem;
using LoliLang.Spell.Lexy.Exceptions;
using LoliLang.Spell.Lexy.ParsingRules;
using AddExpression = LoliLang.Spell.Dryad.AddExpression;
using Daphnaie = LoliLang.Spell.Dryad.Daphnaie;
using Expression = LoliLang.Spell.Dryad.Expression;
using NumberExpression = LoliLang.Spell.Dryad.Types.NumberExpression;
using TypeExpression = LoliLang.Spell.Dryad.Types.TypeExpression;

namespace LoliLang.Spell.Lexy
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

        public Expression AnswersOn(string s)
        {
            var validExpression= LookAt(s)/*.EyeOfTruth().*/.ToList();
            var daphnaie = new Daphnaie(new LoliStack(), null);
            var tree = daphnaie.GrowTreeFrom(validExpression);
            var result = daphnaie.SayWhatIsThe(tree);
            return daphnaie.SayWhatIsThe(tree);
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
           var tokens = line as Token[] ?? line.ToArray();
           for(int i = 0; i < tokens.Count(); i += 2)
           {
               var token = tokens[i];
               if (token.Type is < Token.Forma.Plus and <= Token.Forma.Mul)
                   throw new MissingOperandException(line.Aggregate("", (s, acc) => s + acc.Value));
           }
           return line;
       }


       public static IEnumerable<Token> NormBinaryExpression(this IEnumerable<Token> expression)
       {
           if (expression.Count() != 3)
               throw new ArgumentOutOfRangeException($"{expression.Count()} is not equal to 3");
           
           var normExpression = new List<Token>();

           Token? operation = expression.FirstOrDefault(x => x.Type is >= Token.Forma.Plus and <= Token.Forma.Mul);
           if (!operation.HasValue)
               throw new NullReferenceException($"There is not binary operation in {expression}");
           
           normExpression.Add(operation.Value);
           normExpression.AddRange(expression.Where(x => x.Type != operation.Value.Type));
           
           return normExpression;
       }

   }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using LoliLang.Spell.Lexy.Exceptions;
using LoliLang.Spell.Lexy.ParsingRules;
using Daphnaie = LoliLang.Spell.Dryad.Daphnaie;
using Expression = LoliLang.Spell.Dryad.Expression;
[assembly: InternalsVisibleTo("LoliLang.Spell.Tests")]

namespace LoliLang.Spell.Lexy
{
    public class Lexy
    {
        private IEnumerable<IParsingRule> _rules;
        private readonly Daphnaie _daphnaie;

        
        public Lexy() : this (LexyParsingMagick.RulesBook, new Daphnaie())
        {
        }

        public Lexy(IEnumerable<IParsingRule> rules) : this(rules, new Daphnaie())
        {
        }

        public Lexy(IEnumerable<IParsingRule> rules, Daphnaie daphnaie)
        {
            _rules = rules;
            _daphnaie = daphnaie;
        }

        public Expression AnswerOn(string s)
        {
            var validExpression= LookAt(s)/*.EyeOfTruth().*/.ToList();
            var tree = _daphnaie.GrowTreeFrom(validExpression);
            var result = _daphnaie.SayWhatIsThe();
            return result;
        }
        
        public Expression AnswerOn(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var validExpression= LookAt(line)/*.EyeOfTruth().*/.ToList();
                var tree = _daphnaie.GrowTreeFrom(validExpression);
            }
            var result = _daphnaie.SayWhatIsThe();
            return result;
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
   internal static class LexyParsingMagick
   {
       public static readonly List<string> ReservedWord = new List<string>() 
       {
           "if", "then", "else", " ", "+", "-", "/", "*",
           ">", "<", "==", "=", "true", "false"
       };
       public static readonly List<IParsingRule> RulesBook = new()
       {
           new NumberParsingRule(), 
           new PlusParsingRule(),
           new SubParsingRule(), 
           new MulParsingRule(),
           new DivParsingRule(), 
           new EqParingRule(),
           new LtParingRule(),
           new GtParingRule(),
           new VarNameParsingRule(),
           new DefineParsingRule(),
           new UniqueParsingRule(Token.Forma.If, "if", WordToToken),
           new UniqueParsingRule(Token.Forma.Then, "then",WordToToken),
           new UniqueParsingRule(Token.Forma.Else, "else",WordToToken),
           new UniqueParsingRule(Token.Forma.True, "true",WordToToken),
           new UniqueParsingRule(Token.Forma.False, "false",WordToToken),
       };

       private static Token? WordToToken(Token.Forma forma, string value, string word, string context)
       {
            for (int i = 1; i < context.Length; i++)
            {
                word += context[i];
                (_, string result) = ParseWord(word, context);
                if (result == value)
                    return new Token(result, forma);
            }
            return null;
       }

       public static (string tail, char result) ParseSymbol(char s, string context)
       {
           string tail = string.Empty;
           char result = '\0';
           foreach (var sym in context)
           {
               if (sym != s) tail += sym;
               else result = sym;
           }
           return (tail, result);
       }

       public static (string tail, string result) ParseWord(string word, string context)
       {
           string tail = string.Empty;
           string result = string.Empty;
           
           foreach (var sym in word)
           {
               (string t, char r) = ParseSymbol(sym, context);
               if (r != '\0')
                   result += r;
               tail += tail;
           }
           return (tail, result == word? result : String.Empty);
       }

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
               result = rule.TryOn(symbol.ToString(), expression);
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
               if (token.Type is < Token.Forma.Add and <= Token.Forma.Mul)
                   throw new MissingOperandException(line.Aggregate("", (s, acc) => s + acc.Value));
           }
           return line;
       }
   }
}
using System;

namespace LoliLang.Spell.Lexy.ParsingRules
{
    internal class BinaryOperationParsingRule : IParsingRule
    {
        protected readonly string _value;
        private readonly Token.Forma _forma;
        public BinaryOperationParsingRule(string value, Token.Forma forma)
        {
            _value = value;
            _forma = forma;
        }

        public virtual Token? TryOn(string symbol, string context) => 
            symbol.ToString() == _value ? new Token(_value.ToString(), _forma) : null;
    }
    
    
    internal class UniqueParsingRule : IParsingRule
    {
        protected readonly Token.Forma _forma;
        private readonly string _value;
        protected readonly Func<Token.Forma, string, string, string, Token?> _tryOn;

        public UniqueParsingRule(Token.Forma forma, string value, Func<Token.Forma,string, string, string, Token?> tryOn)
        {
            _forma = forma;
            _value = value;
            _tryOn = tryOn;
        }

        public virtual Token? TryOn(string symbol, string context) => _tryOn(_forma, _value, symbol.ToString(), context);
    }
}
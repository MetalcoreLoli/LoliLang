namespace LoliLang.Lexy.ParsingRules
{
    internal class BinaryOperationParsingRule : IParsingRule
    {
        private readonly char _value;

        private readonly Token.Forma _forma;
        public BinaryOperationParsingRule(char value, Token.Forma forma)
        {
            _value = value;
            _forma = forma;
        }

        public Token? TryOn(char symbol, string context) => 
            symbol == _value ? new Token(_value.ToString(), _forma) : null;
    }
}
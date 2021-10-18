namespace LoliLang.Lexy.ParserRules
{
    internal class PlusParserRule : IParserRule
    {
        public Token? TryOn(char symbol, string context) => 
            symbol is '+' ? new Token("+", Token.Forma.Plus) : null;
    }
}
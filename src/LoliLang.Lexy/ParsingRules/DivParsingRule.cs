namespace LoliLang.Lexy.ParsingRules
{
    internal class DivParsingRule : BinaryOperationParsingRule
    {
        public DivParsingRule() : base('/', Token.Forma.Div)
        {
        }
    }
}
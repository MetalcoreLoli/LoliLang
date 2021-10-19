namespace LoliLang.Lexy.ParsingRules
{
    internal class SubParsingRule : BinaryOperationParsingRule
    {
        public SubParsingRule() : base('-', Token.Forma.Sub)
        {
        }
    }
}
namespace LoliLang.Lexy.ParsingRules
{
    internal class MulParsingRule : BinaryOperationParsingRule
    {
        public MulParsingRule() : base('*', Token.Forma.Mul)
        {
        }
    }
}
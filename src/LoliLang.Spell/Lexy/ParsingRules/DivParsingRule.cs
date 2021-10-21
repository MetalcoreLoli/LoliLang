namespace LoliLang.Spell.Lexy.ParsingRules
{
    internal class DivParsingRule : BinaryOperationParsingRule
    {
        public DivParsingRule() : base('/', Token.Forma.Div)
        {
        }
    }
}
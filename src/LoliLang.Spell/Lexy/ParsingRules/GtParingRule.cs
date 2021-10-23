namespace LoliLang.Spell.Lexy.ParsingRules
{
    internal class GtParingRule : BinaryOperationParsingRule
    {
        public GtParingRule() : base(">", Token.Forma.Gt)
        {
        }
    }
}
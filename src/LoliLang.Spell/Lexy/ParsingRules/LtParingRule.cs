namespace LoliLang.Spell.Lexy.ParsingRules
{
    internal class LtParingRule : BinaryOperationParsingRule
    {
        public LtParingRule() : base("<", Token.Forma.Lt)
        {
        }
    }
}
namespace LoliLang.Spell.Lexy.ParsingRules
{
    internal class DefineParsingRule : BinaryOperationParsingRule
    {
        public DefineParsingRule() : base("=", Token.Forma.Define)
        {
        }
    }
}
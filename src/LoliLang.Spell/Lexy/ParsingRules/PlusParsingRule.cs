namespace LoliLang.Spell.Lexy.ParsingRules
{
    internal class PlusParsingRule :  BinaryOperationParsingRule
    {
        public PlusParsingRule() : base('+', Token.Forma.Plus)
        {
        }
    }
}
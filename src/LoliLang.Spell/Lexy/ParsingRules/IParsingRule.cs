namespace LoliLang.Spell.Lexy.ParsingRules
{
    public interface IParsingRule
    {
        Token? TryOn(char symbol, string context);
    }
}
namespace LoliLang.Spell.Lexy.ParsingRules
{
    public interface IParsingRule
    {
        Token? TryOn(string symbol, string context);
    }
}
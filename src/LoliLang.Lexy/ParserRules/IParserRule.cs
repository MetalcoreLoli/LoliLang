namespace LoliLang.Lexy.ParserRules
{
    public interface IParserRule
    {
        Token? TryOn(char symbol, string context);
    }
}
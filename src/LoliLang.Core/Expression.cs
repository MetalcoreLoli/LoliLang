namespace LoliLang.Core
{
    public abstract class Expression
    {
        public virtual string Value { get; init; }
        public abstract Expression Reduce();
    }
}
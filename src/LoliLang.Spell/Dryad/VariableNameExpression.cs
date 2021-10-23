namespace LoliLang.Spell.Dryad
{
    internal class VariableNameExpression : Expression
    {
        public VariableNameExpression(string name)
        {
            Value = name;
        }

        public override Expression Reduce() => this;
        public override string ToString()
        {
            return Value;
        }
    }
}
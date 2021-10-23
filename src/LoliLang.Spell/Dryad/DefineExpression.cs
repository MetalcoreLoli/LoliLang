namespace LoliLang.Spell.Dryad
{
    internal class DefineExpression : BinaryExpression
    {
        public DefineExpression(Expression left, Expression right) : base(left, right)
        {
        }

        public override Expression Reduce()
        {
            return Right.Reduce();
        }

        public override string ToString() => $"{Left} = {Right}";
    }
}
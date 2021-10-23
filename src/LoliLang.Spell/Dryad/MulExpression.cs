using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class MulExpression : BinaryExpression
    {
        public MulExpression(Expression left, Expression right)
            : base(left, right) { }

        public override Expression Reduce() => (Left.Reduce() as TypeExpression)?.Mul(Right.Reduce());
        public override string ToString() => $"{Left} * {Right}";
    }
}
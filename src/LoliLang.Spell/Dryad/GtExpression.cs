using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class GtExpression : BinaryExpression
    {
        public GtExpression(Expression left, Expression right) : base(left, right)
        {
        }

        public override Expression Reduce() => (Left.Reduce() as TypeExpression)?.Gt(Right.Reduce());

        public override string ToString()
            => $"{Left} == {Right}";
    }
}
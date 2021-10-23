using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class EqExpression : BinaryExpression
    {
        public EqExpression(Expression left, Expression right) : base(left, right)
        {
        }

        public override Expression Reduce() => (Left.Reduce() as TypeExpression)?.Eq(Right.Reduce());

        public override string ToString()
            => $"{Left} == {Right}";
    }
}
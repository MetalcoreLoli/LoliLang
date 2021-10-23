using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class LtExpression : BinaryExpression
    {
        public LtExpression(Expression left, Expression right) : base(left, right)
        {
        }

        public override Expression Reduce() => (Left.Reduce() as TypeExpression)?.Lt(Right.Reduce());

        public override string ToString()
            => $"{Left} == {Right}";
    }
}
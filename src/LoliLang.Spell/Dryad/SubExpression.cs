using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class SubExpression : BinaryExpression
    {
        public SubExpression(Expression left, Expression right)
            : base(left, right)
        {
        }

        public override Expression Reduce() => (Left.Reduce() as TypeExpression)?.Sub(Right.Reduce());
        public override string ToString() => $"{Left} - {Right}";
    }
}
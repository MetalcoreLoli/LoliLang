using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class DivExpression : BinaryExpression
    {
        public DivExpression(Expression left, Expression right)
            : base(left, right) { }

        public override Expression Reduce() => (Left.Reduce() as TypeExpression)?.Div(Right);
        public override string ToString() => $"{Left} / {Right}";
    }
}
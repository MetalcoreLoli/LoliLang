using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class DivExpression : BinaryExpression
    {
        public DivExpression(Types.TypeExpression left, Types.TypeExpression right)
            : base(left, right) { }

        public override Expression Reduce() => (Left.Reduce() as TypeExpression)?.Div(Right);
        public override string ToString() => $"{Left} / {Right}";
    }
}
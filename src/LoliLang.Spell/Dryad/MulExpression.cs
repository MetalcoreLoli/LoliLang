using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class MulExpression : BinaryExpression
    {
        public MulExpression(Types.TypeExpression left, Types.TypeExpression right)
            : base(left, right) { }

        public override Expression Reduce() => (Left as TypeExpression)?.Mul(Right);
        public override string ToString() => $"{Left} * {Right}";
    }
}
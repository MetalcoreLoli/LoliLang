using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class SubExpression : BinaryExpression
    {
        public SubExpression(Expression left, Expression right)
            : base(left, right)
        {
            Value = Reduce().Value;
        }

        public override Expression Reduce() => (Left as TypeExpression)?.Sub(Right);
        public override string ToString() => $"{Left} - {Right}";
    }
}
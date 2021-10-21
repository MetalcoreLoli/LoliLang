
using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class AddExpression : BinaryExpression
    {
        public AddExpression(Expression left, Expression right)
            : base(left, right)
        {
            Value = Reduce().Value;
        }

        public override Expression Reduce()
        {
            var result = (Left as TypeExpression).Add(Right);
            return result;
        }

    public override string ToString() => $"{Left} + {Right}";
    }
}
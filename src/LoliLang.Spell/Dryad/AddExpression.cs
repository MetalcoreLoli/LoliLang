
using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class AddExpression : BinaryExpression
    {
        public AddExpression(Expression left, Expression right)
            : base(left, right)
        {
        }

        public override Expression Reduce()
        {
            var result = (Left.Reduce() as TypeExpression).Add(Right.Reduce());
            return result;
        }

    public override string ToString() => $"{Left} + {Right}";
    }
}
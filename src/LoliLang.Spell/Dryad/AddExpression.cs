
namespace LoliLang.Spell.Dryad
{
    public class AddExpression : BinaryExpression
    {
        public AddExpression(Types.TypeExpression left, Types.TypeExpression right)
            : base(left, right) { }

        public override Expression Reduce() => Left.Add(Right);
        public override string ToString() => $"{Left} + {Right}";
    }
}

namespace LoliLang.Spell.Dryad
{
    public class AddExpression : BinaryExpression
    {
        public AddExpression(Spell.Dryad.Types.TypeExpression left, Spell.Dryad.Types.TypeExpression right)
            : base(left, right) { }

        public override Expression Reduce() => Left.Add(Right);
        public override string ToString() => $"{Left} + {Right}";
    }
}
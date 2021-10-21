namespace LoliLang.Spell.Dryad
{
    public class SubExpression : BinaryExpression
    {
        public SubExpression(Types.TypeExpression left, Types.TypeExpression right)
            : base(left, right) { }

        public override Expression Reduce() => Left.Sub(Right);
        public override string ToString() => $"{Left} - {Right}";
    }
}
namespace LoliLang.Dryad
{
    public class AddExpression : BinaryExpression
    {
        public AddExpression(TypeExpression left, TypeExpression right)
            : base(left, right) { }

        public override Expression Reduce() => Left.Add(Right);
        public override string ToString() => $"{Left} + {Right}";
    }
}
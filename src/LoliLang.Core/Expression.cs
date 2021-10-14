using System;

namespace LoliLang.Core
{
    public abstract class Expression
    {
        public virtual string Value { get; init; }

        public abstract Expression Reduce();
    }

    public class AddExpression : Expression
    {
        public Expression Left { get; init; }
        public Expression Right { get; init; }
        
        public AddExpression(Expression left, Expression right)
        {
            Left = left ?? throw new NullReferenceException("Left expression is null");
            Right = right ?? throw new NullReferenceException("Right expression is null");
        }

        public override Expression Reduce()
        {
            throw new NotImplementedException();
        }
        public override string ToString() => $"{Left} + {Right}";
    }
}
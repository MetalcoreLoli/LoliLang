using System;

namespace LoliLang.Dryad
{
    public abstract class BinaryExpression : Expression
    {
        public TypeExpression Left { get; init; }
        public TypeExpression Right { get; init; }
        public BinaryExpression(TypeExpression left, TypeExpression right)
        {
            Left = left ?? throw new NullReferenceException("Left expression is null");
            Right = right ?? throw new NullReferenceException("Right expression is null");
        }
    }
}
using System;

namespace LoliLang.Spell.Dryad
{
    public abstract class BinaryExpression : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }
        public BinaryExpression(Expression left, Expression right)
        {
            Left = left ?? throw new NullReferenceException("Left expression is null");
            Right = right ?? throw new NullReferenceException("Right expression is null");
        }
    }
}
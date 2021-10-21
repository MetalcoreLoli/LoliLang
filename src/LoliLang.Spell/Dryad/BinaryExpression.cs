using System;

namespace LoliLang.Spell.Dryad
{
    public abstract class BinaryExpression : Expression
    {
        public Spell.Dryad.Types.TypeExpression Left { get; init; }
        public Spell.Dryad.Types.TypeExpression Right { get; init; }
        public BinaryExpression(Spell.Dryad.Types.TypeExpression left, Spell.Dryad.Types.TypeExpression right)
        {
            Left = left ?? throw new NullReferenceException("Left expression is null");
            Right = right ?? throw new NullReferenceException("Right expression is null");
        }
    }
}
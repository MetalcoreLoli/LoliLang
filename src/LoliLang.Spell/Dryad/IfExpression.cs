using System;
using LoliLang.Spell.Dryad.Types;

namespace LoliLang.Spell.Dryad
{
    public class IfExpression : BinaryExpression
    {
        private readonly Expression _condition;

        public Expression Condition => _condition;
        public IfExpression(Expression condition, Expression left, Expression right) : base(left, right)
        {
            _condition = condition;
        }

        public override Expression Reduce()
        {
            return _condition.Reduce().Value switch
            {
                "true" => Left.Reduce(),
                "false" => Right.Reduce(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public override string ToString()
            => $"if {Condition} then {Left} else {Right}";
    }
}
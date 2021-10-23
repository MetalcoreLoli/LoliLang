using System;

namespace LoliLang.Spell.Dryad.Types
{
    public class BoolExpression : Expression
    {
        public BoolExpression(string value)
        {
            Value = value;
        }

        public override Expression Reduce()
        {
            return Value switch
            {
                "True" => new TrueExpression(),
                "False" => new FalseExpression(),
            };
        }


        public override string ToString() => Value;
    }

    public class TrueExpression : BoolExpression
    {
        public TrueExpression() : base("true")
        {
        }

        public override Expression Reduce() => this;
        public override string ToString() => Value;
    }

    public class FalseExpression : BoolExpression
    {
        public FalseExpression() : base("false")
        {
        }

        public override Expression Reduce() => this;
        public override string ToString() => Value;
    }
}
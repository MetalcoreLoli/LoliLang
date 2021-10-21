using System;

namespace LoliLang.Spell.Dryad.Types
{
    public class NumberExpression : ValueTypeExpression
    {
        
        public NumberExpression(string value)
        {
            Value = value;
        }

        public override Expression Reduce() => this;

        public override TypeExpression Add(TypeExpression b)
        {
            throw new NotImplementedException();
        }


        public override string ToString() => Value;
    }
}
using System;

namespace LoliLang.Dryad
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
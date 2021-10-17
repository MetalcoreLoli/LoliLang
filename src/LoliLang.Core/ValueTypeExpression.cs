using System;

namespace LoliLang.Core
{
    public abstract class ValueTypeExpression : TypeExpression
    {
        public override Expression Reduce()
        {
            throw new NotImplementedException();
        }

        public override TypeExpression Add(TypeExpression b)
        {
            throw new NotImplementedException();
        }
    }
}
using System;

namespace LoliLang.Core
{
    public abstract class TypeExpression : Expression
    {
        public abstract TypeExpression Add(TypeExpression b);
    }
}
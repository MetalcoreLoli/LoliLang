using System;

namespace LoliLang.Dryad
{
    public abstract class TypeExpression : Expression
    {
        public abstract TypeExpression Add(TypeExpression b);
    }
}
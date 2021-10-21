using System;

namespace LoliLang.Spell.Dryad.Types
{
    public abstract class TypeExpression : Expression
    {
        public virtual TypeExpression Add(TypeExpression b) => throw new NotImplementedException();
        public virtual TypeExpression Sub(TypeExpression b) => throw new NotImplementedException();
        public virtual TypeExpression Mul(TypeExpression b) => throw new NotImplementedException(); 
        public virtual TypeExpression Div(TypeExpression b) => throw new NotImplementedException();
    }
}
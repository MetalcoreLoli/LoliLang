using System;

namespace LoliLang.Spell.Dryad.Types
{
    public abstract class TypeExpression : Expression
    {
        public virtual Expression Add(Expression b) => throw new NotImplementedException();
        public virtual Expression Sub(Expression b) => throw new NotImplementedException();
        public virtual Expression Mul(Expression b) => throw new NotImplementedException(); 
        public virtual Expression Div(Expression b) => throw new NotImplementedException();
        public virtual Expression Eq(Expression b) => throw new NotImplementedException();
        public virtual Expression Gt(Expression b) => throw new NotImplementedException(); 
        public virtual Expression Lt(Expression b) => throw new NotImplementedException();
    }
}
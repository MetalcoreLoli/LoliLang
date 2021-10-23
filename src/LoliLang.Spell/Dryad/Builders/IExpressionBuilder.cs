
using System;

namespace LoliLang.Spell.Dryad.Builders
{
    public interface IExpressionBuilder
    {
        Expression Answer();
        Expression NewOfType<T>(params  object[] values) where T : Expression;
        IExpressionBuilder With(Expression expression);
        IExpressionBuilder Und(Expression expression);
    }

    public class DryadsMagick : IExpressionBuilder
    {
        public Expression Answer()
        {
            throw new System.NotImplementedException();
        }

        public IExpressionBuilder With(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public IExpressionBuilder Und(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public Expression NewOfType<T>(params object[] values) where T : Expression => 
            (Expression) Activator.CreateInstance(typeof(T), values);
    }
}
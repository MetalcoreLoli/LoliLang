using System;
using System.Data;

namespace LoliLang.Spell.Dryad.Types
{
    public class NumberExpression : ValueTypeExpression
    {
        
        public NumberExpression(string value)
        {
            Value = value;
        }

        public override Expression Reduce() => this;

        public override TypeExpression Add(TypeExpression b) => OperationHelper(b, (l, r) => l + r);
        public override TypeExpression Sub(TypeExpression b) => OperationHelper(b, (l, r) => l - r);
        public override TypeExpression Mul(TypeExpression b) => OperationHelper(b, (l, r) => l * r);
        public override TypeExpression Div(TypeExpression b) => OperationHelper(b, (l, r) => l / r);

        public override string ToString() => Value;

        #region Private Members


        private TypeExpression OperationHelper(TypeExpression b, Func<int, int, int> operation)
        {
            return b switch
            {
                 NumberExpression numberExpression => 
                     new NumberExpression((operation(Number(this), Number(b))).ToString()),
                _ => throw new StrongTypingException($"{b} is of NumberExpression type")
            };
        }

        private int Number(Expression expr) => int.Parse(expr.Reduce().Value);
        #endregion
    }
}
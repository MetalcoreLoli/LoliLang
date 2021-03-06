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

        public override Expression Add(Expression b) => OperationHelper(b, (l, r) => l + r);
        public override Expression Sub(Expression b) => OperationHelper(b, (l, r) => l - r);
        public override Expression Mul(Expression b) => OperationHelper(b, (l, r) => l * r);
        public override Expression Div(Expression b) => OperationHelper(b, (l, r) => l / r);
        public override Expression Eq(Expression b) => OperationBoolHelper(b, (l, r) => l == r);
        public override Expression Gt(Expression b) => OperationBoolHelper(b, (l, r) => l > r);
        public override Expression Lt(Expression b) => OperationBoolHelper(b, (l, r) => l < r);

        public override string ToString() => Value;

        #region Private Members
        private Expression OperationHelper(Expression b, Func<int, int, int> operation)
        {
            return b switch
            {
                { } numberExpression => 
                     new NumberExpression((operation(Number(this), Number(b))).ToString()),
                _ => throw new StrongTypingException($"{b} is of NumberExpression type")
            };
        }
        private Expression OperationBoolHelper(Expression b, Func<int, int, bool> operation)
        {
            return b switch
            {
                { } numberExpression => 
                     new BoolExpression((operation(Number(this), Number(b))).ToString().ToLower()),
                _ => throw new StrongTypingException($"{b} is of NumberExpression type")
            };
        }

        private int Number(Expression expr) => int.Parse(expr.Reduce().Value);
        #endregion
    }
}
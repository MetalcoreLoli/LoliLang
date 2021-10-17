using System;
using LoliLang.Core.Builders;
using LoliLang.Core.Mem;

namespace LoliLang.Core
{
    public class Loli
    {
        private readonly ILoliStack<ValueTypeExpression> _stack;
        private readonly IExpressionBuilder _expressionBuilder;

        public Loli(ILoliStack<ValueTypeExpression> stack, IExpressionBuilder expressionBuilder)
        {
            _stack = stack 
                     ?? throw new NullReferenceException("Implementation of ILoliStack wasn't passed thought constructor or was null");
            _expressionBuilder = expressionBuilder 
                                 ?? throw new NullReferenceException("Expression builder wasn't set ");
        }
        
        public Expression SayWhatIsThe(Expression root)
        {
            throw new NotImplementedException();
        }

        public IExpressionBuilder SayWhatIsThe<T>() where T :Expression
        {
            throw new NotImplementedException();
        }
    }
}
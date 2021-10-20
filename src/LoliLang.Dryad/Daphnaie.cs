using System;
using LoliLang.Dryad.Builders;
using LoliLang.Dryad.Mem;

namespace LoliLang.Dryad
{
    public class Daphnaie
    {
        private readonly ILoliStack<ValueTypeExpression> _stack;
        private readonly IExpressionBuilder _expressionBuilder;

        public Daphnaie(ILoliStack<ValueTypeExpression> stack, IExpressionBuilder expressionBuilder)
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
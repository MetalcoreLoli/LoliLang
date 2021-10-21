using System;
using IExpressionBuilder = LoliLang.Spell.Dryad.Builders.IExpressionBuilder;

namespace LoliLang.Spell.Dryad
{
    public class Daphnaie
    {
        private readonly Spell.Dryad.Mem.ILoliStack<Spell.Dryad.Types.ValueTypeExpression> _stack;
        private readonly IExpressionBuilder _expressionBuilder;

        public Daphnaie(Spell.Dryad.Mem.ILoliStack<Spell.Dryad.Types.ValueTypeExpression> stack, IExpressionBuilder expressionBuilder)
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
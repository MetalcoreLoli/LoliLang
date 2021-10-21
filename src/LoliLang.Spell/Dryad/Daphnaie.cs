using System;
using System.Collections.Generic;
using System.Linq;
using LoliLang.Spell.Dryad.Mem;
using LoliLang.Spell.Dryad.Types;
using LoliLang.Spell.Lexy;
using IExpressionBuilder = LoliLang.Spell.Dryad.Builders.IExpressionBuilder;

namespace LoliLang.Spell.Dryad
{
    public class Daphnaie
    {
        private readonly Spell.Dryad.Mem.ILoliStack<Expression> _stack;
        private readonly IExpressionBuilder _expressionBuilder;

        public Daphnaie(Spell.Dryad.Mem.ILoliStack<Expression> stack, IExpressionBuilder expressionBuilder)
        {
            _stack = stack 
                     ?? throw new NullReferenceException("Implementation of ILoliStack wasn't passed thought constructor or was null");
//            _expressionBuilder = expressionBuilder 
//                                 ?? throw new NullReferenceException("Expression builder wasn't set ");
        }
        
        public Expression SayWhatIsThe(Expression root)
        {
            return root.Reduce();
        }

        public IExpressionBuilder SayWhatIsThe<T>() where T :Expression
        {
            throw new NotImplementedException();
        }

        public Expression GrowTreeFrom(IEnumerable<Token> validExpression)
        {
            return GrowTreeHelper(validExpression, _stack, 0);
        }

        private Expression GrowTreeHelper(
            IEnumerable<Token> validExpression, 
            ILoliStack<Expression> stack, 
            int currentTokenIdx)
        {
            var expression = validExpression as Token[] ?? validExpression.ToArray();
            if (!expression.Any()) return _stack.RemoveNull().Pop();
            return expression.First() switch
            {
                {Type: Token.Forma.Number} t => 
                    GrowTreeHelper (expression.Skip(1),
                        stack.Push(new NumberExpression(t.Value)),
                        currentTokenIdx + 1),
                {Type: Token.Forma.Plus} t => 
                    GrowTreeHelper(expression.Skip(2), 
                        stack
                            .RemoveNull()
                            .Push(new AddExpression(stack.Pop(),GrowTreeHelper(expression.Skip(1), stack, currentTokenIdx + 1))),
                        currentTokenIdx),
                {Type: Token.Forma.Sub} t => 
                    GrowTreeHelper(expression.Skip(2), 
                        stack
                            .RemoveNull()
                            .Push(new SubExpression(stack.Pop(),GrowTreeHelper(expression.Skip(1), stack, currentTokenIdx + 1))),
                        currentTokenIdx),
            };
        }
    }
}
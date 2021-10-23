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
            List<Token> expr = validExpression.ToList();
            return GrowTreeHelper(null, expr);
        }

        private Expression GrowTreeHelper(
            Expression current,
            List<Token> expression 
            )
        {
            if (!expression.Any()) return current;
            var token = expression.First();
            return token switch
            {
                {Type: Token.Forma.Number} t => GrowTreeHelper(new NumberExpression(t.Value), MoveBy(1, expression)),
                {Type: Token.Forma.Plus} t => GrowTreeHelper(
                    new AddExpression(current, GrowTreeRightBranch(expression)), MoveBy(2, expression)),
                {Type: Token.Forma.Sub} t => GrowTreeHelper(
                    new SubExpression(current, GrowTreeRightBranch(expression)), MoveBy(2, expression)),
                _ => throw new ArgumentOutOfRangeException(nameof(token))
            };
        }

        private Expression GrowTreeRightBranch(IEnumerable<Token> expression)
        {
            return GrowTreeHelper(null, new List<Token>() {MoveBy(1, expression).First()});
        }
        
        private List<Token> MoveBy (int step, IEnumerable<Token> expression) => expression.Skip(step).ToList();
    }
}

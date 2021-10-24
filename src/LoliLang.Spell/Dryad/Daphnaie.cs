using System;
using System.Collections.Generic;
using System.Linq;
using LoliLang.Spell.Dryad.Builders;
using LoliLang.Spell.Dryad.Types;
using LoliLang.Spell.Lexy;
using LoliLang.Spell.Mnemosyne;
using IExpressionBuilder = LoliLang.Spell.Dryad.Builders.IExpressionBuilder;

namespace LoliLang.Spell.Dryad
{
    public class Daphnaie
    {
        
        private readonly ILoliStack<Expression> _stack;
        private readonly IExpressionBuilder _magickBook;

        public Daphnaie() : this(
            new LoliStack(), new DryadsMagick())
        {
        }
        
        public Daphnaie(ILoliStack<Expression> stack, IExpressionBuilder expressionBuilder)
        {
            _stack = stack 
                     ?? throw new NullReferenceException("Implementation of ILoliStack wasn't passed thought constructor or was null");
            _magickBook = expressionBuilder 
                                 ?? throw new NullReferenceException("Expression builder wasn't set ");
        }

        internal ILoliStack<Expression> Stack => _stack;

        public Expression SayWhatIsThe()
        {
            var top = _stack.Pop();

            var res = DiveInto(top);
            
            //     if (top is BinaryExpression binaryExpression)
       //     {
       //         var left = binaryExpression.Left.Reduce();
       //         var right = binaryExpression.Right.Reduce();
       //         binaryExpression.Left = GetValueOfVar(left.Value);
       //         binaryExpression.Right= GetValueOfVar(right.Value);
       //         return binaryExpression.Reduce();
       //     }

            return top.Reduce();
        }

        private Expression DiveInto(Expression top)
        {
            if (top is VariableNameExpression var)
                return GetValueOfVar(var.Value);
            if (top is BinaryExpression binaryExpression)
                return DiveIntoBinary(binaryExpression);
            return top;
        }

        private Expression DiveIntoBinary(BinaryExpression binaryExpression)
        {
            if (binaryExpression is DefineExpression) return binaryExpression;
            if (binaryExpression.Left.Reduce() is VariableNameExpression lvar)
                binaryExpression.Left = GetValueOfVar(lvar.Value);
            if (binaryExpression.Right.Reduce() is VariableNameExpression rvar)
                binaryExpression.Right = GetValueOfVar(rvar.Value);


            return binaryExpression;
        }


        public IExpressionBuilder SayWhatIsThe<T>() where T :Expression
        {
            throw new NotImplementedException();
        }

        public Expression GetVarByName(string name)
        {
            return _stack.OfType<DefineExpression>().FirstOrDefault(x => x.Left.Value == name);
        }
        
        public Expression GetValueOfVar(string name) => GetVarByName(name).Reduce();

        public Expression GrowTreeFrom(IEnumerable<Token> validExpression)
        {
            List<Token> expr = validExpression.ToList();
            var res  = GrowTreeHelper(null, expr);
            _stack.Push(res);
            return res;
        }

        private Expression GrowTreeHelper(
            Expression current,
            List<Token> expression 
            )
        {
            if (!expression.Any()) return current;
            var token = expression.First();
            switch (token)
            {
                case {Type: Token.Forma.Number} t:
                    return GrowTreeHelper(_magickBook.NewOfType<NumberExpression>(t.Value), MoveBy(1, expression));
                case {Type: Token.Forma.True} t:
                    return GrowTreeHelper(new TrueExpression(), MoveBy(1, expression));
                case {Type: Token.Forma.False} t:
                    return GrowTreeHelper(new FalseExpression(), MoveBy(1, expression));
                case {Type: Token.Forma.Var} t:
                {
                    var v = new VariableNameExpression(t.Value);

                    var res = GetVarByName(v.Value);
                    if (res is not null)
                        return GrowTreeHelper(res.Reduce(), MoveBy(1, expression));

                    return GrowTreeHelper(v, MoveBy(1, expression));
                }
                case {Type: Token.Forma.If} t:
                {
                    var conditionSubExpr = GetSubTreeFrom(t.Type, Token.Forma.Then, expression);
                    var leftSubExpr = GetSubTreeFrom(Token.Forma.Then, Token.Forma.Else, expression);
                    var rightSubExpr = expression.SkipWhile(x => x.Type != Token.Forma.Else).Skip(1).ToList();

                    var moveStep = conditionSubExpr.Count + leftSubExpr.Count + rightSubExpr.Count + 3;
                    var condition = GrowTreeHelper(null, conditionSubExpr);
                    var left      = GrowTreeHelper(null, leftSubExpr);
                    var right     = GrowTreeHelper(null, rightSubExpr);
                    return GrowTreeHelper(new IfExpression(condition, left, right), MoveBy(moveStep, expression));
                }
                case {Type: Token.Forma.Then}:
                case {Type: Token.Forma.Else}:
                    return GrowTreeHelper(GrowTreeNextValue(expression), MoveBy(1, expression));
                case {Type: Token.Forma.Define}:
                {
                    var rightSubExprBody = MoveBy(1, expression);
                    var rightSubExpr = GrowTreeHelper(null, rightSubExprBody);
                    var var = new DefineExpression(current, rightSubExpr);
                    return GrowTreeHelper(var, MoveBy(rightSubExprBody.Count + 1, expression));
                }
                case {Type: Token.Forma.Eq} t:
                    return GrowTreeHelper(new EqExpression(current, GrowTreeNextValue(expression)),
                        MoveBy(2, expression));
                case {Type: Token.Forma.Lt} t:
                    return GrowTreeHelper(new LtExpression(current, GrowTreeNextValue(expression)),
                        MoveBy(2, expression));
                case {Type: Token.Forma.Gt} t:
                    return GrowTreeHelper(new GtExpression(current, GrowTreeNextValue(expression)),
                        MoveBy(2, expression));
                case {Type: Token.Forma.Add} t:
                    return GrowTreeHelper(new AddExpression(current, GrowTreeNextValue(expression)),
                        MoveBy(2, expression));
                case {Type: Token.Forma.Sub} t:
                    return GrowTreeHelper(new SubExpression(current, GrowTreeNextValue(expression)),
                        MoveBy(2, expression));
                case {Type: Token.Forma.Mul} t:
                    return GrowTreeHelper(new MulExpression(current, GrowTreeNextValue(expression)).Reduce(),
                        MoveBy(2, expression));
                case {Type: Token.Forma.Div} t:
                    return GrowTreeHelper(new DivExpression(current, GrowTreeNextValue(expression)).Reduce(),
                        MoveBy(2, expression));
                default:
                    throw new ArgumentOutOfRangeException(token.ToString());
            }
        }

        private List<Token> GetSubTreeFrom(Token.Forma start, Token.Forma end, IEnumerable<Token> expression)
        {
            return expression.SkipWhile(t => t.Type != start).Reverse().SkipWhile(t => t.Type != end).Reverse().Skip(1).SkipLast(1).ToList();
        }

        private Expression GrowTreeNextValue(IEnumerable<Token> expression, int step = 1)
        {
            return GrowTreeHelper(null, new List<Token>() {MoveBy(step, expression).First()});
        }
        private Token GrowTreeNextToken(IEnumerable<Token> expression, int step = 1)
        {
            return MoveBy(step, expression).First();
        }
        private List<Token> MoveBy (int step, IEnumerable<Token> expression) => expression.Skip(step).ToList();
    }
}

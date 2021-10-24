using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Expression = LoliLang.Spell.Dryad.Expression;

namespace LoliLang.Spell.Mnemosyne
{
    public class LoliStack  : ILoliStack<Expression>
    {
        private readonly Stack<Expression> _stack;

        public LoliStack()
        {
            _stack = new Stack<Expression>();
        }

        public IEnumerator<Expression> GetEnumerator()
        {
            return ((IEnumerable<Expression>) _stack).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Pop() => _stack.Pop();

        public ILoliStack<Expression> Push(Expression value)
        {
            _stack.Push(value);
            return this;
        }

        public ILoliStack<Expression> RemoveNull()
        {
            var array = new Expression[_stack.Count];
            _stack.CopyTo(array, 0);
            _stack.Clear();
            foreach (var expression in array.Where(x => x is not null))
                _stack.Push(expression);
            return this;
        }
    }
}
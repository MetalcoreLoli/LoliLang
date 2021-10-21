using System.Collections.Generic;

namespace LoliLang.Spell.Dryad.Mem
{
    public interface ILoliStack<T> : IEnumerable<T>
    {
        T Pop();
        ILoliStack<T> Push(T value);
    }
}
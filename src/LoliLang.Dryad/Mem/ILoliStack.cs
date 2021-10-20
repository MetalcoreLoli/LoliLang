using System.Collections.Generic;

namespace LoliLang.Dryad.Mem
{
    public interface ILoliStack<T> : IEnumerable<T>
    {
        T Pop();
        ILoliStack<T> Push(T value);
    }
}
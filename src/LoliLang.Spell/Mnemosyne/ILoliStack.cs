using System.Collections.Generic;

namespace LoliLang.Spell.Mnemosyne
{
    public interface ILoliStack<T> : IEnumerable<T>
    {
        T Pop();
        ILoliStack<T> Push(T value);

        ILoliStack<T> RemoveNull();
    }
}
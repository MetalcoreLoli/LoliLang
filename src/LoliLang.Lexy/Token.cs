using System.Collections.Generic;

namespace LoliLang.Lexy
{
    public readonly struct Token
    {
        public Token(string value, Forma type)
            => (Value, Type) = (value, type);
        public string Value { get; init; }
        public Forma Type { get; init; }

        public override string ToString() => $"[{Type};{Value}]";

        public enum Forma: byte
        {
            Number = 0,
            Plus = 1,
            Sub  = 2,
            Div  = 3,
            Mul  = 4,
        }
    }
}
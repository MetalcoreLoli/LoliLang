using System;

namespace LoliLang.Spell.Lexy.Exceptions
{
    public class MissingOperandException : Exception
    {

        public MissingOperandException(string expression) : base($"Missing operand in expression \"{expression}\"")
        {
        }
    }
}
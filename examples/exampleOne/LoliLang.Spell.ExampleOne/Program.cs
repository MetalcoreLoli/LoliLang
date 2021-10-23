using System;
using LoliLang.Spell.Lexy;

namespace LoliLang.Spell.ExampleOne
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lexy = new Lexy.Lexy();

            Console.WriteLine("Result: "+lexy.AnswersOn("if 2 / 2 == 1 then 1 else 0").Value);
        }
    }
}
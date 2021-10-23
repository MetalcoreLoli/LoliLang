using System;

namespace LoliLang.Spell.ExampleOne
{
    internal class Program
    {
        private static void Main()
        {
            var lexy = new Lexy.Lexy();

            Console.WriteLine("Result: "+lexy.AnswerOn("if 2/2==1 then true else false").Value);
        }
    }
}
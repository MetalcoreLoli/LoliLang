using System;

namespace LoliLang.Spell.ExampleOne
{
    internal class Program
    {
        private static void Main()
        {
            var lexy = new Lexy.Lexy();

            Console.WriteLine("Result: "+lexy.AnswerOn("if 2/2==1 then true else false"));
            Console.WriteLine("Result: "+lexy.AnswerOn("a = if 2/2==1 then 1 else false").Value);
            Console.WriteLine("Result: "+lexy.AnswerOn("a + 1").Value);
        }
    }
}
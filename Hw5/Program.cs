using System;

namespace Hw5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IChat chat = new Chat();
            chat = new DecoratorBuilder(chat)
                .WithHide()
                .WithEncode()
                .Build();
            var mail1 = chat.Send("Bob", "Jack", "Hi, Jack!");
            mail1.ForEach(i => Console.WriteLine(i));
            Console.WriteLine();
            var mail2 = chat.Receive("Jack", "Bob", "Hi, Bob!");
            mail2.ForEach(i => Console.WriteLine(i));
            Console.WriteLine();
        }
    }
}
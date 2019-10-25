using System;
using Hw3.MailBuilder;

namespace Hw3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RunMailBuilder();
            
            Console.ReadLine();
        }

        private static void RunMailBuilder()
        {
            var mailer = new MailBuilder();
            var director = new MailBuilderDirector(mailer);
            director.Build("name", "text");
            var mail = mailer.Result;
            Console.WriteLine($"{mail.Receiver} : {mail.Copy} : {mail.Title}: {mail.Text}");
        }
        
    }
}
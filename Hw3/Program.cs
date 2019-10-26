using System;
using System.Collections.Generic;
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
            var mailer = new MailBuilder.MailBuilder();
            var director = new MailBuilderDirector(mailer);
            List<string> receivers = new List<string> { "name1", "name2"};
            List<string> copies = new List<string> { "copy1"}; 
            director.Build(receivers, copies, "title", "text");
            var mail = mailer.Result;
            mail.Receiver.ForEach(delegate(String name) {
                name = name + " ";
                Console.Write(name);
            });
            Console.WriteLine();
            mail.Copy.ForEach(delegate(String name) {
                name = name + " ";
                Console.Write(name);
            });
            Console.WriteLine();
            Console.WriteLine(mail.Title);
            Console.WriteLine(mail.Text);
        }
        
    }
}
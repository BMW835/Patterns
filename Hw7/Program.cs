using System.Collections.Generic;
using Hw7.State;

namespace Hw7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tracer = new Tracer(100, "USB",  new[] {"*FIRST LIST*", "*SECOND LIST*", "*THIRD LIST*"});
            tracer.GetMoney();
            tracer.ChooseDevice();
            tracer.ChooseDoc();
            for (int i = 0; i <= tracer.Docs.Length; i++)
            {
                tracer.ChooseDoc();
                tracer.PrintDoc();
            }
            tracer.GiveChange();
        }
    }
}
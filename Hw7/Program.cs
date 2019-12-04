using System.Collections.Generic;
using Hw7.State;

namespace Hw7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var folder = new[] {"*FIRST LIST*", "*SECOND LIST*", "*THIRD LIST*"};
            var tracer = new Tracer(100, "USB",  folder);
            tracer.GetMoney();
            tracer.ChooseDevice();
            tracer.ChooseDoc();
            for (int i = 0; i <= folder.Length*2; i++)
            {
                tracer.PrintDoc();
            }
            tracer.GiveChange();
        }
    }
}
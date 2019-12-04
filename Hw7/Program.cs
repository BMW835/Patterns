using System.Collections.Generic;
using Hw7.State;

namespace Hw7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tracer = new Tracer(100, "USB",  new string[]{"first list", "second list", "third list"});
            tracer.GetMoney();
            tracer.ChooseDevice();
            
        }
    }
}
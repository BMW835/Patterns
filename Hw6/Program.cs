using System;
using Example_06.ChainOfResponsibility;

namespace Hw6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var Euro = new Bancomat("537 Euro");
            var Dollars = new Bancomat("285 Dollar");
            var Rubles = new Bancomat("2312 Ruble");
        }
    }
}
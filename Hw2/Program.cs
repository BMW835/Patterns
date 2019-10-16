using System;
using Hw2.MyFactory;

namespace Hw2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyFactory();
            Console.ReadKey();
        }
        
        #region MyFactory

        public static void MyFactory()
        {
            var bmw = new BmwCar();
            MakeCar(bmw);
            
            var audi = new AudiCar();
            MakeCar(audi);
        }
        public static void MakeCar(ICarFactory car)
        {
            Console.WriteLine(car.CreateBody().Name);
            Console.WriteLine(car.CreateEngine().Name);
            Console.WriteLine(car.CreateCabin().Name);
            Console.WriteLine(car.CreateTransmission().Name);
            Console.WriteLine(car.CreateWheels().Name);
            Console.WriteLine(car.Assemble().Name);
            Console.WriteLine();

        }
        #endregion
    }
}
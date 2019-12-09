using System.Collections.Generic;
using Hw8.Visitor;

namespace Hw8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Figures[] figures =
            {
                new Rectangle(new List<int> {1, 2}),
                new Triangle(new List<int> {3, 3, 3}),
                new Circle(new List<int> {4})
            };
            var drawVisitor = new DrawVisitor();
            var getAreaVisitor = new GetAreaVisitor();
            var getPerimeterVisitor = new GetPerimeterVisitor();
            foreach (var plant in figures)
            {
                plant.Accept(drawVisitor);
                plant.Accept(getAreaVisitor);
                plant.Accept(getPerimeterVisitor);
            }
        }
    }
}
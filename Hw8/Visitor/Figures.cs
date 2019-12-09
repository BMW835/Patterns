using System;
using System.Collections.Generic;

namespace Hw8.Visitor
{
    
    #region Visitors
        
    public interface IVisitor
    {
        string OperationName { get; }
        void Visit(Rectangle figure);
        void Visit(Triangle figure);
        void Visit(Circle figure);
    }

    public class DrawVisitor : IVisitor
    {
        public string OperationName => "Draw";
        
        public void Visit(Rectangle figure)
        {
            Console.WriteLine($"Draw a line of {figure.Sides[0]} cm, then {figure.Sides[1]} cm, then {figure.Sides[0]} cm, then {figure.Sides[1]} cm\n");
        }

        public void Visit(Triangle figure)
        {
            Console.WriteLine($"Draw a line of {figure.Sides[0]} cm, then {figure.Sides[1]} cm, then {figure.Sides[2]} cm\n");
        }

        public void Visit(Circle figure)
        {
            Console.WriteLine($"Draw a circle of {figure.Sides[0]} cm radius\n");
        }
    }

    public class GetAreaVisitor : IVisitor
    {
        public string OperationName => "GetArea";

        public void Visit(Rectangle figure)
        {
            Console.WriteLine($"The area is {figure.Sides[0] * figure.Sides[1]} sq. cm\n");
        }

        public void Visit(Triangle figure)
        {
            var a = figure.Sides[0];
            var b = figure.Sides[1];
            var c = figure.Sides[2];
            var p = (double)(a + b + c) / 2;
            Console.WriteLine($"The area is {Math.Sqrt(p * (p - a) * (p - b) * (p - c))} sq. cm\n");
        }

        public void Visit(Circle figure)
        {
            Console.WriteLine($"The area is {Math.PI * figure.Sides[0] * figure.Sides[0]} sq. cm\n");
        }
    }
    
    public class GetPerimeterVisitor : IVisitor
    {
        public string OperationName => "GetArea";

        public void Visit(Rectangle figure)
        {
            Console.WriteLine($"The perimeter is {2 * (figure.Sides[0] + figure.Sides[1])} cm\n");
        }

        public void Visit(Triangle figure)
        {
            Console.WriteLine($"The perimeter is {figure.Sides[0] + figure.Sides[1] + figure.Sides[2]} cm\n");
        }

        public void Visit(Circle figure)
        {
            Console.WriteLine($"The perimeter is {2 * Math.PI * figure.Sides[0]} cm\n");
        }
    }
    
    #endregion

    #region Elements

    public abstract class Figures
    {
        public abstract string Name { get; }

        public List<int> Sides { get; }

        public Figures(List<int> sides){
            Sides = sides;
        }

        public abstract void Accept(IVisitor visitor);
    }

    public class Rectangle : Figures
    {
        public override string Name => "Rectangle";

        public Rectangle(List<int> sides) : base(sides) {}
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Triangle : Figures
    {
        public override string Name => "Triangle";

        public Triangle(List<int> sides) : base(sides) {}
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Circle : Figures
    {
        public override string Name => "Circle";

        public Circle(List<int> sides) : base(sides) {}
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    #endregion
    
}
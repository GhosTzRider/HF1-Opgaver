using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF1_OOP_øvelser_med_nedarvning
{
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double radius)
    {
        Radius = radius;
    }
        public override double GetArea()
    {
        return Math.PI * Radius * Radius;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    public class Rectangle : Shape
    {
       public double Height { get; set; }
       public double length { get; set; }

       public Rectangle(double height, double length)
       {
           Height = height;
           this.length = length;
       }
        public override double GetArea()
        {
            return Height * length;
        }
        public override double GetPerimeter()
        {
            return 2 * (Height + length);
        }
    }
}


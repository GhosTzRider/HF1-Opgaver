using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF1_Øvelser_med_interfaces
{
    internal interface IPrintable
    {
        void Print(string text);
    }

    public class Invoice : IPrintable
    {
        public void Print(string text)
        {
            Console.WriteLine($"Invoice: {text}");
        }
    }

    public class Report : IPrintable
    {
        public void Print(string text)
        {
            Console.WriteLine($"Report: {text}");
        }
    }

    public class Letter : IPrintable
    {
        public void Print(string text)
        {
            Console.WriteLine($"Letter: {text}");
        }
    }

    
}

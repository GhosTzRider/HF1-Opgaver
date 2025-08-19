using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF1_Øvelser_med_interfaces
{
    public interface IDriveable
    {
        public void Start();
        public void Stop();
    }

    public class Vehicle : IDriveable
    {
        public string Brand { get; set; }
        public void Start()
        {
            Console.WriteLine("The vehicle is driving.");
        }
        public void Stop()
        {
            Console.WriteLine("The vehicle has stopped.");
        }
    }

    public class Car : Vehicle
    {
        public void Start()
        {
            Console.WriteLine("The car is driving.");
        }
        public void Stop()
        {
            Console.WriteLine("The car has stopped.");
        }
    }

    public class Motorcycle : Vehicle
    {
        public void Start()
        {
            Console.WriteLine("The motercycle is driving.");
        }
        public void Stop()
        {
            Console.WriteLine("The motorcycle has stopped.");
        }
    }
}

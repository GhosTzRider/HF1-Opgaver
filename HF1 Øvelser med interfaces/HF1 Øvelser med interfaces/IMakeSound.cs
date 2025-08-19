using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF1_Øvelser_med_interfaces
{
    public interface IMakeSound
    {
        public void MakeSound();
    }

    public class Dog : IMakeSound
    {
        public void MakeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }
    }
    public class Cat : IMakeSound
    {
        public void MakeSound()
        {
            Console.WriteLine("Meow! Meow!");
        }
    }
    public class Cow : IMakeSound
    {
        public void MakeSound()
        {
            Console.WriteLine("Moo! Moo!");
        }
    }
}

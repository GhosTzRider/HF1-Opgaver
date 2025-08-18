using HF1_OOP_øvelser_med_nedarvning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF1_OOP_øvelser_med_nedarvning
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract void MakeSound();
    }
public class Lion : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Roar");
    }
}

public class Elephant : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Trumpet");
    }
}

public class Parrot : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Kraw");
    }
}
}


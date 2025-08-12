using System;
using System.Collections.Generic;

namespace HF1_Yatsy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
        }
    }
}

public class Dice
{
    public int roll()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }
}

public class Spiller
{
    public string Name { get; set; }
    public int Score { get; set; }
    public Spiller(string name)
    {
        Name = name;
        Score = 0;
    }
    public void AddScore(int points)
    {
        Score += points;
    }
}


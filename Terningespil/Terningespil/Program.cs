using System.Collections;

namespace Terningespil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            Console.WriteLine("how many dices do you want to roll: ");
            int numberOfDices = int.Parse(Console.ReadLine() ?? "1");
            for (int i = 0; i < numberOfDices; i++)
            {
                dice.Roll();
                Console.WriteLine($"Dice {i + 1} rolled: {dice.Value}");
            }
        }
    }
}


public class Dice
{
    public int Value { get; private set; }
    public void Roll()
    {
        Random rnd = new Random();
        Value = rnd.Next(1, 7);
    }
}
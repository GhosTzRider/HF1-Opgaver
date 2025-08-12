using System;
using System.IO;
using System.Media;

namespace HF1_Mozart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What instrument would you like: piano, mbira, flute-harp or clarinet");
            string InstrumentPicker = Console.ReadLine();
            Console.WriteLine("Minuet or Trio?: ");
            string MinuetOrTrio = Console.ReadLine();

            PathFinder pathFinder = new PathFinder(Path.Combine("mozart", InstrumentPicker.ToLower()));
            string filePath = pathFinder.FindPath;
            Console.WriteLine(filePath);

            Die die = new Die(new Random());

            for (int i = 0; i <= 15; i++)
            {
                int roll;
                if (MinuetOrTrio.Equals("trio", StringComparison.OrdinalIgnoreCase))
                {
                    roll = die.RollOnedice();
                }
                else
                {
                    roll = die.RollTwodice();
                }
                Console.WriteLine($"Rolled a {roll}");
                string soundFile = Path.Combine(filePath, $"{MinuetOrTrio.ToLower()}{i}-{roll}.wav");
                Console.WriteLine(soundFile);

                if (File.Exists(soundFile))
                {
                    using (SoundPlayer player = new SoundPlayer(soundFile))
                    {
                        player.PlaySync();
                    }
                }
                else
                {
                    Console.WriteLine($"File not found: {soundFile}");
                }
            }
        }
    }
}

public class Die
{
    private readonly Random _rng;
    public Die(Random rng) => _rng = rng;

    public int RollOnedice() => _rng.Next(1, 7);
    public int RollTwodice() => RollOnedice() + RollOnedice();
}

public class PathFinder
{
    public string FindPath { get; set; }
    public PathFinder(string filepath)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        FindPath = Path.Combine(currentDirectory, filepath);
    }
}
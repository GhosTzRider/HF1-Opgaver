using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Random random = new Random();

    static string[] categories = {
        "1'ere", "2'ere", "3'ere", "4'ere", "5'ere", "6'ere",
        "Et par", "To par", "Tre ens", "Fire ens",
        "Lille straight", "Stor straight", "Fuldt hus",
        "Chance", "Yatzy"
    };

    class Player
    {
        public string Name;
        public int?[] Scores = new int?[categories.Length];
    }

    static void Main()
    {
        int playerCount;
        do
        {
            Console.Write("Hvor mange spillere? (2-6): ");
        } while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount < 2 || playerCount > 6);

        List<Player> players = new List<Player>();
        for (int i = 0; i < playerCount; i++)
        {
            Console.Write("Navn på spiller " + (i + 1) + ": ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) name = "Spiller" + (i + 1);
            players.Add(new Player { Name = name });
        }

        for (int round = 0; round < categories.Length; round++)
        {
            foreach (Player player in players)
            {
                Console.Clear();
                Console.WriteLine("Runde " + (round + 1) + " - " + player.Name);

                List<int> savedDice = new List<int>();
                List<int> rollingDice = RollDice(5);

                ShowDice(savedDice, rollingDice);

                for (int rollNumber = 1; rollNumber <= 2; rollNumber++)
                {
                    Console.WriteLine("Skriv numrene på terninger du vil gemme (adskilt med mellemrum) eller tryk Enter for at slå igen:");
                    string input = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        string[] parts = input.Split(' ');
                        List<int> toSave = new List<int>();

                        foreach (string part in parts)
                        {
                            if (int.TryParse(part, out int index))
                            {
                                index -= 1;
                                if (index >= 0 && index < rollingDice.Count && !toSave.Contains(index))
                                {
                                    toSave.Add(index);
                                }
                            }
                        }

                        toSave.Sort();
                        toSave.Reverse();

                        foreach (int i in toSave)
                        {
                            savedDice.Add(rollingDice[i]);
                            rollingDice.RemoveAt(i);
                        }
                    }

                    if (rollingDice.Count > 0)
                        rollingDice = RollDice(rollingDice.Count);

                    ShowDice(savedDice, rollingDice);

                    if (savedDice.Count == 5)
                        break;
                }

                savedDice.AddRange(rollingDice);
                int[] finalDice = savedDice.ToArray();

                ShowAvailableCategories(player);

                int categoryChoice;
                while (true)
                {
                    Console.WriteLine(player.Name + ", vælg en kategori (nummer):");
                    if (int.TryParse(Console.ReadLine(), out categoryChoice) && categoryChoice >= 1 && categoryChoice <= categories.Length && player.Scores[categoryChoice - 1] == null)
                    {
                        break;
                    }
                    Console.WriteLine("Ugyldigt valg eller kategori brugt, prøv igen.");
                }

                int points = CalculateScore(categories[categoryChoice - 1], finalDice);
                player.Scores[categoryChoice - 1] = points;

                Console.WriteLine("Du fik " + points + " point i " + categories[categoryChoice - 1]);
                Console.WriteLine("Tryk en tast for at fortsætte...");
                Console.ReadKey();
            }
        }

        Console.Clear();
        Console.WriteLine("Spillet er slut! Resultater:");
        foreach (Player p in players)
        {
            int total = 0;
            foreach (var score in p.Scores)
            {
                if (score != null) total += score.Value;
            }
            Console.WriteLine(p.Name + ": " + total + " point");
        }
    }

    static List<int> RollDice(int count)
    {
        List<int> dice = new List<int>();
        for (int i = 0; i < count; i++)
        {
            dice.Add(random.Next(1, 7));
        }
        return dice;
    }

    static void ShowDice(List<int> saved, List<int> rolling)
    {
        Console.WriteLine("Gemte terninger: " + (saved.Count > 0 ? string.Join(" ", saved) : "ingen"));
        Console.WriteLine("Rullende terninger:");
        for (int i = 0; i < rolling.Count; i++)
        {
            Console.Write("[" + (i + 1) + ":" + rolling[i] + "] ");
        }
        Console.WriteLine();
    }

    static void ShowAvailableCategories(Player player)
    {
        Console.WriteLine("Kategorier:");
        for (int i = 0; i < categories.Length; i++)
        {
            if (player.Scores[i] == null)
            {
                Console.WriteLine((i + 1) + ". " + categories[i]);
            }
        }
    }

    static int CalculateScore(string category, int[] dice)
    {
        switch (category)
        {
            case "1'ere": return dice.Count(d => d == 1) * 1;
            case "2'ere": return dice.Count(d => d == 2) * 2;
            case "3'ere": return dice.Count(d => d == 3) * 3;
            case "4'ere": return dice.Count(d => d == 4) * 4;
            case "5'ere": return dice.Count(d => d == 5) * 5;
            case "6'ere": return dice.Count(d => d == 6) * 6;
            case "Et par": return OnePair(dice);
            case "To par": return TwoPair(dice);
            case "Tre ens": return ThreeOfAKind(dice);
            case "Fire ens": return FourOfAKind(dice);
            case "Lille straight": return SmallStraight(dice);
            case "Stor straight": return LargeStraight(dice);
            case "Fuldt hus": return FullHouse(dice);
            case "Chance": return dice.Sum();
            case "Yatzy": return Yatzy(dice);
            default: return 0;
        }
    }

    static int OnePair(int[] dice)
    {
        var pairs = dice.GroupBy(d => d).Where(g => g.Count() >= 2).Select(g => g.Key * 2);
        return pairs.Any() ? pairs.Max() : 0;
    }

    static int TwoPair(int[] dice)
    {
        var pairs = dice.GroupBy(d => d).Where(g => g.Count() >= 2).Select(g => g.Key).OrderByDescending(k => k).Take(2).ToList();
        if (pairs.Count == 2)
        {
            return pairs[0] * 2 + pairs[1] * 2;
        }
        return 0;
    }

    static int ThreeOfAKind(int[] dice)
    {
        var three = dice.GroupBy(d => d).Where(g => g.Count() >= 3).Select(g => g.Key * 3);
        return three.Any() ? three.Max() : 0;
    }

    static int FourOfAKind(int[] dice)
    {
        var four = dice.GroupBy(d => d).Where(g => g.Count() >= 4).Select(g => g.Key * 4);
        return four.Any() ? four.Max() : 0;
    }

    static int SmallStraight(int[] dice)
    {
        var s = dice.OrderBy(d => d).ToArray();
        if (s.SequenceEqual(new[] { 1, 2, 3, 4, 5 })) return 15;
        return 0;
    }

    static int LargeStraight(int[] dice)
    {
        var s = dice.OrderBy(d => d).ToArray();
        if (s.SequenceEqual(new[] { 2, 3, 4, 5, 6 })) return 20;
        return 0;
    }

    static int FullHouse(int[] dice)
    {
        var groups = dice.GroupBy(d => d).Select(g => g.Count()).OrderBy(c => c).ToArray();
        if (groups.SequenceEqual(new[] { 2, 3 })) return dice.Sum();
        return 0;
    }

    static int Yatzy(int[] dice)
    {
        if (dice.Distinct().Count() == 1) return 50;
        return 0;
    }
}

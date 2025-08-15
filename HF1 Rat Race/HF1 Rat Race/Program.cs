using System;
using System.Collections.Generic;

namespace HF1_Rat_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new RaceManager();
            var bookmaker = new Bookmaker();

            // Create track (fixed length for all races)
            var track = manager.CreateTrack("Downtown Dash", 30);

            // Create rats
            var rat1 = manager.CreateRat("Speedy");
            var rat2 = manager.CreateRat("Cheddar");
            var rat3 = manager.CreateRat("Nibbles");

            // Create player
            var player = manager.CreatePlayer("You", 100);

            Console.WriteLine(" Welcome to the Rat Race! ");

            // Game loop
            while (player.Money > 0)
            {
                Console.WriteLine($"\n💰 You have {player.Money} coins.");
                Console.WriteLine("Rats in the race:");
                for (int i = 0; i < manager.Rats.Count; i++)
                    Console.WriteLine($"{i + 1}. {manager.Rats[i].Name}");

                // --- Betting Phase ---
                int ratChoice;
                while (true)
                {
                    Console.Write("Choose the rat number to bet on: ");
                    if (int.TryParse(Console.ReadLine(), out ratChoice) && ratChoice >= 1 && ratChoice <= manager.Rats.Count)
                        break;
                    Console.WriteLine("Invalid choice, try again.");
                }
                Rat chosenRat = manager.Rats[ratChoice - 1];

                int betAmount;
                while (true)
                {
                    Console.Write("How much do you want to bet? ");
                    if (int.TryParse(Console.ReadLine(), out betAmount) && betAmount > 0 && betAmount <= player.Money)
                        break;
                    Console.WriteLine("Invalid bet amount, try again.");
                }

                // Create new race for each game
                var race = manager.CreateRace($"Race{manager.Races.Count + 1}", new List<Rat>
                {
                    new Rat(rat1.Name),
                    new Rat(rat2.Name),
                    new Rat(rat3.Name)
                }, track);

                bookmaker.PlaceBet(race, chosenRat, player, betAmount);

                // --- Race Phase ---
                Console.WriteLine("\n🏁 Race starting!");
                int round = 1;
                bool raceOver = false;
                while (!raceOver)
                {
                    Console.WriteLine($"\n--- Round {round} ---");
                    foreach (var rat in race.Rats)
                    {
                        int roll = RNG.Range(1, 6); // 1–6 like Ludo
                        rat.Move(roll);
                        Console.WriteLine($"{rat.Name} rolled {roll} and is now at {rat.Position}");

                        if (rat.Position >= race.RaceTrack.TrackLength)
                        {
                            raceOver = true;
                            race.SetWinner(rat);
                            break;
                        }
                    }
                    round++;
                }

                // --- Results Phase ---
                string winner = race.GetWinner();
                Console.WriteLine($"\n Winner is: {winner}");

                foreach (var bet in bookmaker.Bets)
                {
                    if (bet.Rat.Name == winner)
                    {
                        int winnings = bet.Money * 2;
                        Console.WriteLine($"🎉 {bet.Player.Name} won {winnings} coins!");
                        bet.Player.Money += winnings;
                    }
                    else
                    {
                        Console.WriteLine($"💔 {bet.Player.Name} lost {bet.Money} coins.");
                    }
                }

                bookmaker.Bets.Clear(); // Reset bets for next round
            }

            Console.WriteLine("\n Game Over! You lost all your coins.");
        }
    }

    public class Track
    {
        public string Name { get; set; }
        public int TrackLength { get; set; }
    }

    public static class RNG
    {
        private static Random random = new Random();

        public static int Range(int lower, int upper)
        {
            return random.Next(lower, upper + 1);
        }
    }

    public class Rat
    {
        public string Name { get; set; }
        public int Position { get; set; }

        public Rat(string name)
        {
            Name = name;
            Position = 0;
        }

        public void Move(int distance)
        {
            Position += distance;
        }
    }

    public class Race
    {
        public string RaceID { get; set; }
        public List<Rat> Rats { get; set; }
        public Track RaceTrack { get; set; }
        private Rat Winner { get; set; }

        public void SetWinner(Rat rat)
        {
            Winner = rat;
        }

        public string GetWinner()
        {
            return Winner?.Name ?? "No Winner";
        }
    }

    public class Bet
    {
        public int Money { get; set; }
        public Player Player { get; set; }
        public Race Race { get; set; }
        public Rat Rat { get; set; }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<Bet> Bets { get; set; } = new List<Bet>();
    }

    public class Bookmaker
    {
        public List<Bet> Bets { get; set; } = new List<Bet>();

        public Bet PlaceBet(Race race, Rat rat, Player player, int money)
        {
            player.Money -= money;
            var bet = new Bet { Race = race, Rat = rat, Player = player, Money = money };
            Bets.Add(bet);
            player.Bets.Add(bet);
            Console.WriteLine($"{player.Name} bet {money} coins on {rat.Name}");
            return bet;
        }
    }

    public class RaceManager
    {
        public List<Track> Tracks { get; private set; }
        public List<Player> Players { get; private set; }
        public List<Race> Races { get; private set; }
        public List<Rat> Rats { get; private set; }

        public RaceManager()
        {
            Tracks = new List<Track>();
            Players = new List<Player>();
            Races = new List<Race>();
            Rats = new List<Rat>();
        }

        public Race CreateRace(string raceID, List<Rat> rats, Track track)
        {
            var race = new Race
            {
                RaceID = raceID,
                Rats = rats,
                RaceTrack = track
            };
            Races.Add(race);
            return race;
        }

        public Track CreateTrack(string name, int trackLength)
        {
            var track = new Track
            {
                Name = name,
                TrackLength = trackLength
            };
            Tracks.Add(track);
            return track;
        }

        public Rat CreateRat(string name)
        {
            var rat = new Rat(name);
            Rats.Add(rat);
            return rat;
        }

        public Player CreatePlayer(string name, int money)
        {
            var player = new Player { Name = name, Money = money };
            Players.Add(player);
            return player;
        }
    }
}

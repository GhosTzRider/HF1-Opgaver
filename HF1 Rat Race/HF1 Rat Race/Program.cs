using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace HF1_Rat_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

public class Track
{
    public string NameOfTrack(string name)
    {
        return name;
    }
    public int LengthOfTrack(int length)
    {
        return length;
    }
}

public class RNG
{
    public static List<int> RollDice(int count)
    {
        Random random = new Random();
        List<int> dice = new List<int>();
        for (int i = 0; i < count; i++)
        {
            dice.Add(random.Next(1, 7));
        }
        return dice;
    }
}

public class Rat
{
    public string Name { get; set; }
    public int Position { get; set; }
    public Rat(string name, int speed)
    {
        Name = name;
        Position = 0;
    }
    public void Move(int distance)
    {
        Position += distance;
    }
    public void ResetPosition()
    {
        Position = 0;
    }
}

public class Race
{
    public List<Rat> Rats { get; set; }
    public Track RaceTrack { get; set; }
    public string RaceID { get; set; }
    private string RatWinner { get; set; }
    private string Log { get; set; } = string.Empty;

    public void ConductRace()
    {
        RaceTrack = new Track();
    }

    public string GetWinner()
    {
        int maxPosition = int.MinValue;
        string winner = string.Empty;
        foreach (var rat in Rats)
        {
            if (rat.Position > maxPosition)
            {
                maxPosition = rat.Position;
                winner = rat.Name;
            }
        }
        RatWinner = winner;
        return RatWinner;
    }

    public string GetRaceReport()
    {
        return Log;
    }

    public void LogRace(string message)
    {
        Log += message + Environment.NewLine;
    }
}

public class betting
{
    public string BetID { get; set; }
    public string RatName { get; set; }
    public int Amount { get; set; }
    public string Status { get; set; } = "Pending";
    public void PlaceBet(string ratName, int amount)
    {
        RatName = ratName;
        Amount = amount;
        BetID = Guid.NewGuid().ToString();
    }
    public void SettleBet(bool isWinner)
    {
        Status = isWinner ? "Won" : "Lost";
    }
}

public class Player
{
    public string Name { get; set; }
    public List<betting> Bets { get; set; } = new List<betting>();
    
    public void PlaceBet(string ratName, int amount)
    {
        betting bet = new betting();
        bet.PlaceBet(ratName, amount);
        Bets.Add(bet);
    }
    public void SettleBets(string winner)
    {
        foreach (var bet in Bets)
        {
            bet.SettleBet(bet.RatName == winner);
        }
    }
}

public class Bookmarker
{
    public string Name { get; set; }
    public List<betting> Bets { get; set; } = new List<betting>();
    
    public void PlaceBet(string ratName, int amount)
    {
        betting bet = new betting();
        bet.PlaceBet(ratName, amount);
        Bets.Add(bet);
    }
    
    public void SettleBets(string winner)
    {
        foreach (var bet in Bets)
        {
            bet.SettleBet(bet.RatName == winner);
        }
    }
}

public class RaceManager
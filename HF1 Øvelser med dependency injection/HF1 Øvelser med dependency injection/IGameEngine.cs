using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF1_Øvelser_med_dependency_injection
{
    public interface IGameEngine
    {
        void play();
    }

    public class GuessNumberGame : IGameEngine
    {
        public void play()
        {
            Console.WriteLine("Playing Guess the Number!");
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);
            int playerGuess = 0;
            while (playerGuess != numberToGuess)
            {
                Console.Write("Enter your guess (1-100): ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out playerGuess))
                {
                    if (playerGuess < numberToGuess)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else if (playerGuess > numberToGuess)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You've guessed the number!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                }
            }
        }
    }

    public class RockPapirScissorsGame : IGameEngine
    {
        public void play()
        {
            Console.WriteLine("Playing Rock, Paper, Scissors!");
            string[] choices = { "Rock", "Paper", "Scissors" };
            Random random = new Random();

            Console.Write("Enter your choice (Rock, Paper, Scissors): ");
            string? playerChoice = Console.ReadLine();

            if (playerChoice == null || !choices.Contains(playerChoice, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            string computerChoice = choices[random.Next(choices.Length)];
            Console.WriteLine($"Computer chose: {computerChoice}");

            playerChoice = choices.First(c => c.Equals(playerChoice, StringComparison.OrdinalIgnoreCase));

            Console.Write("Result: ");
            if (playerChoice == computerChoice)
            {
                Console.WriteLine("It's a tie!");
            }
            else if ((playerChoice == "Rock" && computerChoice == "Scissors") ||
                     (playerChoice == "Paper" && computerChoice == "Rock") ||
                     (playerChoice == "Scissors" && computerChoice == "Paper"))
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }
        }
    }

    public class GameRunner
    {
        private readonly IGameEngine _gameEngine;

        public GameRunner(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public void Run()
        {
            _gameEngine.play();
        }
    }
}

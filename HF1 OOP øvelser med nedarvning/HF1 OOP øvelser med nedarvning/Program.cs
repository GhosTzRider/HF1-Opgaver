using System;
using System.Collections.Generic;

namespace HF1_OOP_øvelser_med_nedarvning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Bicycle bicycle = new Bicycle();
            car.Drive();
            bicycle.Drive();

            List<Animal> animals = new List<Animal>
            {
                new Lion(),
                new Elephant(),
                new Parrot()
            };
            foreach (var animal in animals)
            {
                animal.MakeSound();
            }

            Payment payment = new MyCreditCardPayment();
            MyCreditCardPayment myPayment = new MyCreditCardPayment();
            Payment PayPalPayment = new PayPalPayment();
            myPayment.ProcessPayment();
            PayPalPayment.ProcessPayment();
            PayPalPayment.ProcessPayment();

            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(4, 6);
            Console.WriteLine($"Circle Area: {circle.GetArea()}");
            Console.WriteLine($"Circle Perimeter: {circle.GetPerimeter()}");

            Character player1 = new Warrior("Aragorn", 100, 20);
            Character player2 = new Mage("Gandalf", 80, 30);
            while (player1.Health > 0 && player2.Health > 0)
            {
                player1.Health -= player2.Attack();
                player2.Health -= player1.Attack();
                Console.WriteLine($"{player1.Name} Health: {player1.Health}");
                Console.WriteLine($"{player2.Name} Health: {player2.Health}");
                Console.WriteLine($"{player1.Name} attacks with damage: {player1.Attack()}");
                Console.WriteLine($"{player2.Name} attacks with damage: {player2.Attack()}");
            }
            if (player1.Health <= 0)
            {
                Console.WriteLine($"{player2.Name} wins!");
            }
            else if (player2.Health <= 0)
            {
                Console.WriteLine($"{player1.Name} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }


        }
    }

public class Vehicle
{
    public string Brand { get; set; }
    public string MaxSpeed { get; set; }
    public string Drive()
    {
        Console.WriteLine("The vehicle is driving");
        return "The vehicle is driving";
    }
}

public class Car
{
    public string NumberOfDoors { get; set; }
    public void Drive()
    {
        Console.WriteLine("The car is driving");
    }
}

public class Bicycle
{
    public string HasBell { get; set; }
    public void Drive()
    {
        Console.WriteLine("The bicycle is pedaling");
    }
}
}

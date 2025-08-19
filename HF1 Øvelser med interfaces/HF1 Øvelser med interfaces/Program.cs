using System.Security.Cryptography.X509Certificates;

namespace HF1_Øvelser_med_interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment();
            PayPalPayment payPalPayment = new PayPalPayment();
            Ipayment paymentMethod;
            creditCardPayment.ProcessPayment(100.00m);
            payPalPayment.ProcessPayment(50.00m);

            List<IPrintable> printables = new List<IPrintable>
            {
                new Invoice(),
                new Report(),
                new Letter()
            };
            foreach (var printable in printables)
            {
                printable.Print("This is a sample text.");
            }

            Car car = new Car();
            Motorcycle motorcycle = new Motorcycle();
            car.Start();
            car.Stop();
            motorcycle.Start();
            motorcycle.Stop();

            List<IMakeSound> animals = new List<IMakeSound>
            {
                new Dog(),
                new Cat(),
                new Cow()
            };
            foreach (var animal in animals)
            {
                animal.MakeSound();
            }

            List<IWeapon> weapons = new List<IWeapon>
            {
                new Sword(),
                new Bow(),
                new Staff()
            };
            foreach (var weapon in weapons)
            {
                int attackDamage = weapon.Attack();
                Console.WriteLine($"Attack power: {attackDamage}");

            }
        }
    }
    
    public interface Ipayment
    {
        public void ProcessPayment(decimal amount);
    }

    public class CreditCardPayment : Ipayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C}");
        }
    }

    public class PayPalPayment : Ipayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
        }
    }
}

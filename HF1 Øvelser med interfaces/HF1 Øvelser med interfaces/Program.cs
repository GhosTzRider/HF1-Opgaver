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

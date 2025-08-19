using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF1_Øvelser_med_dependency_injection
{
    internal interface IPaymentProcessor
    {
        void Process(decimal amount);
    }

    public class StripePaymentProcessor : IPaymentProcessor
    {
        public void Process(decimal amount)
        {
            Console.WriteLine($"Processing Stripe payment of {amount:C}");
        }
    }

    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void Process(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
        }
    }
    public class CheckoutService
    {
        private readonly IPaymentProcessor _paymentProcessor;
        public CheckoutService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }
        public void Checkout(decimal amount)
        {
            _paymentProcessor.Process(amount);
            Console.WriteLine("Checkout completed successfully.");
        }
    }
}

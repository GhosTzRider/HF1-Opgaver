using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF1_OOP_øvelser_med_nedarvning
{
    public class Payment
    {
        public string Amout { get; set; }
        public string Currency { get; set; }
        public string ProcessPayment()
        {
            Console.WriteLine("Processing genetic payment");
            return "Processing genetic payment";
        }
    }
    public class MyCreditCardPayment : Payment
    {
        public string CreditCardPayment { get; set; }
        int CardNumber { get; set; }
        public string ProcessPayment()
        {
            Console.WriteLine("Processing credit card payment");
            return "Processing credit card payment";
        }
    }

    public class PayPalPayment : Payment
    {
        public string Email { get; set; }
        public string ProcessPayment()
        {
            Console.WriteLine("Processing PayPal payment");
            return "Processing PayPal payment";
        }
    }
}
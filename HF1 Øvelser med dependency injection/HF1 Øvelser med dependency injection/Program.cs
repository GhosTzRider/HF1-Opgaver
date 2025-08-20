using System;
using System.IO;

namespace HF1_Øvelser_med_dependency_injection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            var userService = new UserService(logger);
            userService.CreateUser("Alice");

            ILogger fileLogger = new FileLogger("UserLog.txt");
            var fileUserService = new UserService(fileLogger);
            fileUserService.CreateUser("Bob");

            StripePaymentProcessor stripePaymentProcessor = new StripePaymentProcessor();
            PayPalPaymentProcessor payPalPaymentProcessor = new PayPalPaymentProcessor();
            CheckoutService checkoutService;

            Console.WriteLine("What payment method do you want to use: Stripe or Paypal");
            string paymentMethod = Console.ReadLine()?.ToLower();
            if (paymentMethod == "stripe")
            {
                checkoutService = new CheckoutService(stripePaymentProcessor);
            }
            else if (paymentMethod == "paypal")
            {
                checkoutService = new CheckoutService(payPalPaymentProcessor);
            }
            else
            {
                Console.WriteLine("Invalid payment method selected. Defaulting to Stripe.");
                checkoutService = new CheckoutService(stripePaymentProcessor);
            }
            checkoutService.Checkout(100.00m);

            SmtpEmailSender smtpEmailSender = new SmtpEmailSender();
            ConsoleEmailSender consoleEmailSender = new ConsoleEmailSender();
            NotificationService notificationService;

            Console.WriteLine("What email service do you want to use: SMTP or Console");
            string emailService = Console.ReadLine()?.ToLower();
            if (emailService == "smtp")
            {
                notificationService = new NotificationService(smtpEmailSender);
            }
            else if (emailService == "console")
            {
                notificationService = new NotificationService(consoleEmailSender);
            }
            else
            {
                Console.WriteLine("Invalid email service selected. Defaulting to SMTP.");
                notificationService = new NotificationService(smtpEmailSender);
            }
            notificationService.SendEmail("Coworker", "Work", "Today");

            IProductRepository inMemoryProductRepository = new InMemoryProductRepository();
            inMemoryProductRepository.AddProduct("Laptop");
            inMemoryProductRepository.AddProduct("Smartphone");
            IProductRepository sqlProductRepository = new SqlProductRepository();
            ProductService productService;
            Console.WriteLine("What product repository do you want to use: InMemory or SQL");
            string productRepositoryChoice = Console.ReadLine()?.ToLower();
            if (productRepositoryChoice == "inmemory")
            {
                productService = new ProductService(inMemoryProductRepository);
            }
            else if (productRepositoryChoice == "sql")
            {
                productService = new ProductService(sqlProductRepository);
            }
            else
            {
                Console.WriteLine("Invalid product repository selected. Defaulting to InMemory.");
                productService = new ProductService(inMemoryProductRepository);
            }
            productService.AddProduct("Tablet");


            Console.WriteLine("Which game do you want to play: GuessNumber or RockPapirScissors");
            string? gameChoice = Console.ReadLine()?.ToLower();
            IGameEngine selectedGame;
            if (gameChoice == "guessnumber")
            {
                selectedGame = new GuessNumberGame();
            }
            else if (gameChoice == "rockpapirscissors")
            {
                selectedGame = new RockPapirScissorsGame();
            }
            else
            {
                Console.WriteLine("Invalid game choice. Defaulting to Guess Number Game.");
                selectedGame = new GuessNumberGame();
            }
            var gameRunner = new GameRunner(selectedGame);
            gameRunner.Run();

            Console.WriteLine("Thank you for playing!");
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string fileName = "Log.txt")
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            _filePath = Path.Combine(directory, fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
        }

        public void Log(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }

    public class UserService
    {
        private readonly ILogger _logger;
        public UserService(ILogger logger)
        {
            _logger = logger;
        }
        public void CreateUser(string username)
        {
            _logger.Log($"User '{username}' created successfully.");
        }
    }
}


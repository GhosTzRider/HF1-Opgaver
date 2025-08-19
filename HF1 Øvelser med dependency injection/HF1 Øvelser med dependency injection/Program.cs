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


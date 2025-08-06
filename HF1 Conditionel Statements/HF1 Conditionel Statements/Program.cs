namespace HF1_Conditionel_Statements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("the result is: " + AbsolutValue(-5.0));

            Console.WriteLine("the result is: " + DivisibleBy2Or3(7, 12));

            Console.WriteLine("the result is: " + IfConsistsOfOnlyUppercaseLetters("Hej"));

            Console.WriteLine("the result is: " + GreaterThanThirdNumber(5, 10, 20));

            Console.WriteLine("the result is: " + IsEven(4));

            Console.WriteLine("the result is: " + IsSortedAscending(1, 2, 3));

            Console.WriteLine("the result is: " + PositiveOrNegative(0));

            Console.WriteLine("the result is: " + IfYearIsLeapYear(2004));
        }

        static double AbsolutValue(double number)
        {

            if (number < 0)
            {
                return -number;
            }
            else
            {
                return number;
            }


        }


        static int DivisibleBy2Or3(int a, int b)
        {
            if ((a % 2 == 0 || a % 3 == 0) && (b % 2 == 0 || b % 3 == 0))
            {
                return a * b;
            }
            else
            {
                return a + b;
            }
        }




        static string IfConsistsOfOnlyUppercaseLetters(string text)
        {
            if (!string.IsNullOrEmpty(text) && text.All(c => char.IsUpper(c) && char.IsLetter(c)))
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }


        static bool GreaterThanThirdNumber(int a, int b, int c)
        {
            List<int> numbers = new List<int>();

            numbers.Add(a);
            numbers.Add(b);
            numbers.Add(c);

            if (a + b > c || a * b > c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsEven(int number) { if (number % 2 == 0) { return true; } else { return false; } }


        static bool IsSortedAscending(int a, int b, int c)
        {
            List<int> numbers = new List<int>();
            numbers.Add(a);
            numbers.Add(b);
            numbers.Add(c);

            if (numbers[0] <= numbers[1] && numbers[1] <= numbers[2])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static String PositiveOrNegative(int number)
        {
            if (number > 0)
            {
                return "positive";
            }
            else if (number < 0)
            {
                return "negative";
            }
            else
            {
                return "zero";
            }
        }


        static bool IfYearIsLeapYear(int year)
        {
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


namespace HF1_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddAndMultiply(2, 4, 5);
            Console.WriteLine("The result is: " + AddAndMultiply(2, 4, 5));

            Console.WriteLine("Enter a temperature in Celsius: ");
            string input = Console.ReadLine();
            Console.WriteLine("The temperature in Fahrenheit is: " + ConvertingToFahrenheit(Convert.ToDouble(input), 0));

            Console.WriteLine("the result of elementary methods is: " + Elementarymethods(3, 8));

            Console.WriteLine("The result of is result the same is: " + IsResultTheSame(2, 2, 9, 3));

            Console.WriteLine("The result of modulo operations is: " + ModuloOperations(8, 5, 2));

            Console.WriteLine("The result of the cube of is: " + TheCubeOf(2));

            Console.WriteLine("The Result of swapping two numbers is: " + SwapTwoNumbers(87, 45));

        }

        static int AddAndMultiply(int a, int b, int c)
        {
            return (a + b) * c;
        }


        static double ConvertingToFahrenheit(double Celsius, double fahrenheit)
        {

            if (Celsius < -300)
            {
                Console.WriteLine("Temperature cannot be below absolute zero.");
            }

            return ((Celsius * 9.0 / 5.0) + 32);
 

        }
        static String Elementarymethods(double a, double b)
        {
            double addition = a + b;
            double subtraction = a - b;
            double multiplication = a * b;
            double division = a / b;

            string result = addition.ToString() + ", " +
                            subtraction.ToString() + ", " +
                            multiplication.ToString() + ", " +
                            division.ToString();
            return result;

        }


        static String IsResultTheSame(double a, double b, double c, double d)
        {

            double addition = a + b;
            double multiplication = a * b;
            bool isEqual = addition == multiplication;

            double subtraction = c - d;
            double division = c / d;
            bool isEquall = subtraction == division;

            return $"Addition: {addition}, Multiplication: {multiplication}, Are Equal: {isEqual},\n" +
                   $"Subtraction: {subtraction}, Division: {division}, Are Equal: {isEquall}";
        }



        static String ModuloOperations(double a, double b, double c)
        {

            double modulo = (a % b) % c;
            return $"The result of {a} % {b} is: {modulo}";

        }


        static double TheCubeOf(double a)
        {
            double result = a * a * a;
            return result;
        }


        static Array SwapTwoNumbers(double a, double b)
        {
            double[] array = new double[2];
            array[0] = a;
            array[1] = b;
            Console.WriteLine("Before swapping: a = " + array[0] + ", b = " + array[1]);


            double temp = array[0];
            array[0] = array[1];
            array[1] = temp;
            Console.WriteLine("After swapping: a = " + array[0] + ", b = " + array[1]);


            return array;
        }
    }
}
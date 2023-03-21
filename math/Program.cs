using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math
{
    class Program
    {
        static void Main(string[] args)
        {
            int fromBase, toBase;
            string number;

            do
            {
                Console.Clear();
                Console.Write("Enter the number you want to convert: ");
                number = Console.ReadLine();

                Console.Write("Enter the base of the number you want to convert: ");
                fromBase = int.Parse(Console.ReadLine());

                Console.Write("Enter the base you want to convert to: ");
                toBase = int.Parse(Console.ReadLine());

                string result = ConvertNumberBase(number, fromBase, toBase);

                Console.WriteLine(number + " in the base: " + fromBase + "," + " Converts to " + result + " in base: " + toBase);

                Console.ReadLine();

                Console.WriteLine("Press 'Y' to convert another number, or any other key to exit the program.");

            }
            while (Console.ReadKey().Key == ConsoleKey.Y);

        }

        static string ConvertNumberBase(string number, int fromBase, int toBase)
        {
            int decimalNumber = ConvertToDecimal(number, fromBase);
            string result = ConvertFromDecimal(decimalNumber, toBase);
            return result;
        }

        static int ConvertToDecimal(string number, int fromBase)
        {
            int decimalNumber = 0;
            int power = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                try
                {
                int digit = CharToDigit(number[i]);
                decimalNumber += digit * (int)Math.Pow(fromBase, power);
                power++;

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }

            return decimalNumber;
        }

        static string ConvertFromDecimal(int decimalNumber, int toBase)
        {
            string result = "";

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % toBase;
                char digit = DigitToChar(remainder);
                result = digit + result;
                decimalNumber /= toBase;
            }

            return result;
        }

        static int CharToDigit(char c)
        {
            if (char.IsDigit(c))
            {
                return (int)char.GetNumericValue(c);
            }
            else
            {
                return (int)c - (int)'A' + 10;
            }
        }

        static char DigitToChar(int digit)
        {
            if (digit < 10)
            {
                return (char)(digit + '0');
            }
            else
            {
                return (char)(digit - 10 + 'A');
            }
        }
    }
}


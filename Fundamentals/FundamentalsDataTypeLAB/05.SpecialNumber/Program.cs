using System;

namespace SpecialNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int sumDigits = 0;
                int digit = i;

                while (digit > 0)
                {
                    sumDigits += digit % 10;
                    digit /= 10;
                }
                bool isSpecial = false;

                if (sumDigits == 5 || sumDigits == 7 || sumDigits == 11)
                {
                    isSpecial = true;
                }

                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}

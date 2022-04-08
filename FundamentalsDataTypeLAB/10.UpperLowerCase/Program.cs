using System;

namespace UpperLowerCase
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = Console.ReadLine()[0];

            if (letter >= 65 && letter <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if (letter >= 97 && letter <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}

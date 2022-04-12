using System;
using System.Text;

namespace LetterDigitOrOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder letters = new StringBuilder();
            StringBuilder digits = new StringBuilder();
            StringBuilder chars = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                bool symbols = char.IsLetter(input[i]);
                if (symbols)
                {
                    letters.Append(input[i]);
                    continue;
                }

                bool digit = char.IsDigit(input[i]);
                if (digit)
                {
                    digits.Append(input[i]);
                    continue;
                }

                chars.Append(input[i]);
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(chars);
        }
    }
}

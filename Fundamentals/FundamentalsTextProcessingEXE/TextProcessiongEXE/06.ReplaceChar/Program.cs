using System;
using System.Text;

namespace _06.ReplaceChar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < text.Length - 1 ; i++)
            {
                if (text[i] != text[i + 1])
                {
                    stringBuilder.Append(text[i]);
                }
            }
            stringBuilder.Append(text[text.Length - 1]);
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}

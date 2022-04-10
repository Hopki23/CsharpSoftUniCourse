using System;
using System.Text;

namespace _7.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeat = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatedString(input, repeat));
        }


        static string RepeatedString(string command, int times)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < times; i++)
            {
                stringBuilder.Append(command);
            }
            return stringBuilder.ToString();
        }
    }
}

using System;

namespace DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > daysOfWeek.Length)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(daysOfWeek[number - 1]);
            }
        }
    }
}

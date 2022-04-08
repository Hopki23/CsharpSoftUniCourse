using System;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses =(int)Math.Ceiling((double)countOfPeople / capacity);
            Console.WriteLine(courses);
        }
    }
}

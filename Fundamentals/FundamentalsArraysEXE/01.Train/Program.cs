using System;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[] people = new int[input];
            int sum = 0;

            for (int i = 0; i < input; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
                sum += people[i];
            }
            Console.WriteLine(String.Join(" ", people));
            Console.WriteLine(sum);
        }
    }
}

using System;
using System.Linq;

namespace CommonElements2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ');
            string[] secondInput = Console.ReadLine().Split(' ');

            var intersect = firstInput.Intersect(secondInput);

            foreach (var item in intersect)
            {
                Console.Write(item + " ");
            }
        }
    }
}

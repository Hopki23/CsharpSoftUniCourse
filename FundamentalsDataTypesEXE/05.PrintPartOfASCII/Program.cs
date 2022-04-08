using System;

namespace PrintPartOfASCII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                char currentSymbol =(char)i;
                Console.Write(currentSymbol + " ");
            }
        }
    }
}

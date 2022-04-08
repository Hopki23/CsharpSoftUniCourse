using System;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());        //N
            int distance = int.Parse(Console.ReadLine());        // M
            int exhaustionFactor = int.Parse(Console.ReadLine()); //Y 
            int pokeCounter = 0;
            int startingPower = pokePower;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                pokeCounter++;

                if (pokePower == startingPower * 0.5)
                {
                    if (exhaustionFactor == 0)
                    {
                        continue;
                    }
                    else
                    {
                        pokePower /= exhaustionFactor;
                    }
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokeCounter);
        }
    }
}

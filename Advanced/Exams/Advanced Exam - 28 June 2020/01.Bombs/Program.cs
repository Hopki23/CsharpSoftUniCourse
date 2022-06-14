using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daturaBomb = 0, cherryBomb = 0, decoyBomb = 0;

            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (true)
            {
                if (daturaBomb >= 3 && cherryBomb >= 3 && decoyBomb >= 3)
                {
                    break;
                }

                if (bombEffects.Count == 0 || bombCasing.Count == 0)
                {
                    break;
                }

                int currentEffect = bombEffects.Peek();
                int currentCasing = bombCasing.Pop();

                if (currentEffect + currentCasing == 40)
                {
                    currentEffect = bombEffects.Dequeue();
                    daturaBomb++;
                }
                else if (currentEffect + currentCasing == 60)
                {
                    currentEffect = bombEffects.Dequeue();
                    cherryBomb++;
                }
                else if (currentEffect + currentCasing == 120)
                {
                    currentEffect = bombEffects.Dequeue();
                    decoyBomb++;
                }
                else
                {
                    bombCasing.Push(currentCasing - 5);
                }
            }

            if (daturaBomb >= 3 && cherryBomb >= 3 && decoyBomb >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }

            if (bombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBomb}");
            Console.WriteLine($"Datura Bombs: {daturaBomb}");
            Console.WriteLine($"Smoke Decoy Bombs: {decoyBomb}");
        }
    }
}

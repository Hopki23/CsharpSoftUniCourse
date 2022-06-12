using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DippingSauce = 150;
            const int GreenSalad = 250;
            const int ChokolateCake = 300;
            const int Lobster = 400;

            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>()
            {
                {"Dipping sauce", 0 },
                {"Green salad",0 },
                {"Chocolate cake",0 },
                {"Lobster",0 }
            };

            while (true)
            {
                if (ingredients.Count == 0 || freshness.Count == 0)
                {
                    break;
                }
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }
                int currentFreshness = freshness.Pop();

                if (currentIngredient * currentFreshness == DippingSauce)
                {
                    dishes["Dipping sauce"]++;
                }
                else if (currentIngredient * currentFreshness == GreenSalad)
                {
                    dishes["Green salad"]++;
                }
                else if (currentIngredient * currentFreshness == ChokolateCake)
                {
                    dishes["Chocolate cake"]++;
                }
                else if (currentIngredient * currentFreshness == Lobster)
                {
                    dishes["Lobster"]++;
                }
                else
                {
                    ingredients.Enqueue(currentIngredient + 5);
                }
            }

            if (dishes["Dipping sauce"] > 0 && dishes["Green salad"] > 0 && dishes["Chocolate cake"] > 0 && dishes["Lobster"] > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishes)
            {
                if (dish.Value == 0)
                {
                    continue;
                }

                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}

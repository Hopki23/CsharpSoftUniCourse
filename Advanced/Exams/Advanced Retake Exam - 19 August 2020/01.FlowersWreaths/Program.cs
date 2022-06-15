using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowersWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> roses = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> lillies = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int sum = 0;
            int wreathCounter = 0;
            while (true)
            {
                if (roses.Count == 0 || lillies.Count == 0)
                {
                    break;
                }
                int currentRose = roses.Pop();
                int currentLillies = lillies.Dequeue();

                if (currentRose + currentLillies == 15)
                {
                    wreathCounter++;
                }
                else if (currentRose + currentLillies > 15)
                {
                    currentLillies -= 2;
                    while (true)
                    {
                        if (currentRose + currentLillies == 15)
                        {
                            wreathCounter++;
                            break;
                        }
                        else if (currentRose + currentLillies < 15)
                        {
                            sum += currentRose + currentLillies;
                            break;
                        }

                        currentLillies -= 2;
                    }
                }
                else if (currentRose + currentLillies < 15)
                {
                    sum += currentRose + currentLillies;
                }
            }

            if (sum / 15 > 0)
            {
                wreathCounter += sum / 15;
            }

            if (wreathCounter >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCounter} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCounter} wreaths more!");
            }
        }
    }
}

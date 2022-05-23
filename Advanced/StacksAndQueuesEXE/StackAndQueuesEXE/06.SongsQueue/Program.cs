using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> songsQueue = new Queue<string>(songs);

            while (true)
            {
                string cmd = Console.ReadLine();

                if (songsQueue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
                if (cmd == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (cmd.StartsWith("Add"))
                {
                    var songFullname = cmd.Substring(4);

                    if (songsQueue.Contains(songFullname) == false)
                    {
                        songsQueue.Enqueue(songFullname);
                    }
                    else
                    {
                        Console.WriteLine($"{songFullname} is already contained!");
                    }
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ",songsQueue));
                }
            }
        }
    }
}

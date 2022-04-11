using System;
using System.Collections.Generic;

namespace Songs
{
    public class Song
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < numOfSongs; i++)
            {
                string[] tokens = Console.ReadLine().Split("_", StringSplitOptions.RemoveEmptyEntries);

                Song song = new Song()
                {
                    Type = tokens[0],
                    Name = tokens[1],
                    Time = tokens[2]
                };
                songs.Add(song);
            }

            string command = Console.ReadLine();

            if (command == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                var filteredSongs = songs.FindAll(x => x.Type == command);

                foreach (var song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }       
    }
}

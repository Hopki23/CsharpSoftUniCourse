using System;
using System.Collections.Generic;

namespace _08.SoftuniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                names.Add(input);
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                if (names.Contains(cmd))
                {
                    names.Remove(cmd);
                }
            }
            Console.WriteLine(names.Count);
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}

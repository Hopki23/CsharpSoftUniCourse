using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = new List<string>(); 
            string pattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                phoneNumbers.Add(match.Value);
            }
            Console.WriteLine(string.Join(", ",phoneNumbers));
        }
    }
}

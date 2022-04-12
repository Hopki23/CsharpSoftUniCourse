using System;

namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();            
            string substring = path.Substring(path.LastIndexOf('\\') + 1);
            string fileName = substring.Substring(0, substring.LastIndexOf('.'));
            string extension = substring.Substring(substring.LastIndexOf('.') + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}

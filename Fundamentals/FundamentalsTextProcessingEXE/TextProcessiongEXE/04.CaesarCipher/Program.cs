using System;
using System.Text;
using System.Linq;
namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder encryptedText = new StringBuilder();      
          

            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];
                int value = currChar + 3;
                char ch = (char)value;
                encryptedText.Append(ch);
            }
            Console.WriteLine(encryptedText.ToString());
        }
    }
}

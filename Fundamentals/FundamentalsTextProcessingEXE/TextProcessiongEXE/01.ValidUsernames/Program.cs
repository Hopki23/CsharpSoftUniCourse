using System;

namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            bool isValid = false;
            foreach (var username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    for (int i = 0; i < username.Length; i++)
                    {
                        char currCh = username[i];
                        if (char.IsLetterOrDigit(currCh) || currCh == '_' || currCh == '-')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                else
                {
                    isValid = false;
                }

                if (isValid)
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}

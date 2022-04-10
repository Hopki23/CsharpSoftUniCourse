using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            if (@operator == "/")
            {
                int result = PrintDivision(firstNum, @operator, secondNum);
                Console.WriteLine(result);
            }
            else if (@operator == "*")
            {
                int result = PrintMultiply(firstNum, @operator, secondNum);
                Console.WriteLine(result);
            }
            else if (@operator == "+")
            {
                int result = PrintAddition(firstNum, @operator, secondNum);
                Console.WriteLine(result);
            }
            else if (@operator == "-")
            {
                int result = PrintSubtraction(firstNum, @operator, secondNum);
                Console.WriteLine(result);
            }
        }

        static int PrintSubtraction(int firstNum, string @operator, int secondNum)
        {
            int result = firstNum - secondNum;
            return result;
        }

        static int PrintAddition(int firstNum, string @operator, int secondNum)
        {

            int result = firstNum + secondNum;
            return result;
        }

        static int PrintMultiply(int firstNum, string @operator, int secondNum)
        {
            int result = firstNum * secondNum;
            return result;
        }

        static int PrintDivision(int a, string @operator, int b)
        {
            int result = a / b;
            return result;
        }
    }
}

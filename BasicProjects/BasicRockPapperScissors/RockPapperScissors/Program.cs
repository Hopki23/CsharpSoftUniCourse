using System;

namespace RockPapperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Rock = "rock";
            const string Paper = "paper";
            const string Scissors = "scissors";
            bool hasQuit = false;

            while (true)
            {
                if (hasQuit)
                {
                    break;
                }
                Console.Write("Choose [r]ock, [p]aper or [s]cissors: ");
                string playerMove = Console.ReadLine();

                if (playerMove == "r" || playerMove == "rock")
                {
                    playerMove = Rock;
                }
                else if (playerMove == "s" || playerMove == "scissors")
                {
                    playerMove = Paper;
                }
                else if (playerMove == "p" || playerMove == "paper")
                {
                    playerMove = Scissors;
                }
                else
                {
                    Console.WriteLine("Invalid input! Try Again");
                    return;
                }

                Random rand = new Random();
                int computerMoveNum = rand.Next(1, 4);
                string computerMove = string.Empty;

                if (computerMoveNum == 1)
                {
                    computerMove = Rock;
                }
                else if (computerMoveNum == 2)
                {
                    computerMove = Paper;
                }
                else if (computerMoveNum == 3)
                {
                    computerMove = Scissors;
                }

                Console.WriteLine($"Computer choose: {computerMove}");

                if (playerMove == Rock && computerMove == Scissors ||
                    playerMove == Paper && computerMove == Rock ||
                    playerMove == Scissors && computerMove == Paper)
                {
                    Console.WriteLine("Congratulations, You win!");
                }
                else if (computerMove == Rock && playerMove == Scissors ||
                         computerMove == Scissors && playerMove == Paper ||
                    computerMove == Paper && playerMove == Rock)
                {
                    Console.WriteLine("Sorry, You lost! Good luck next time!");
                }
                else
                {
                    Console.WriteLine("It's a draw!");
                }

                Console.WriteLine("Do you want do continiue? Yes or No?");
                string continiueToPlay = Console.ReadLine();

                if (continiueToPlay == "Yes")
                {
                    continue;
                }
                else if (continiueToPlay == "No")
                {
                    hasQuit = true;
                    Console.WriteLine("Bye bye!");
                }
                else
                {
                    Console.WriteLine("Wrong answer!");
                    while (continiueToPlay != "Yes" || continiueToPlay != "No")
                    {
                        continiueToPlay = Console.ReadLine();
                        if (continiueToPlay == "Yes")
                        {
                            break;
                        }
                        else if (continiueToPlay == "No")
                        {
                            Console.WriteLine("Bye bye!");
                            return;
                        }
                    }
                }
            }
        }
    }
}

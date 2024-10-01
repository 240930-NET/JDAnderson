using System;

namespace RockPaperScissors
{
    class Guess
    {
        public static void GameInfo()
        {
            Console.WriteLine("This is a rock paper Scissors game \nbelow are your options\n");
            Console.WriteLine("Rock");
            Console.WriteLine("Scissors");
            Console.WriteLine("Paper");
        }

        private static string UserInput()
        {
            while (true)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine()?.Trim().ToLower() ?? "";

                switch (input)
                {
                    case "rock":
                        return "Rock";
                    case "scissors":
                        return "Scissors";
                    case "paper":
                        return "Paper";
                    default:
                        Console.WriteLine("Invalid input. Please enter Rock, Paper, or Scissors.");
                        break;
                }
            }
        }

        public static void play()
        {
            bool continuePlaying = true;

            while (continuePlaying)
            {
                GameInfo();
                string userChoice = UserInput();
                string computersChoice = ComputerChoice();
                Console.WriteLine($"You chose: {userChoice}");
                Console.WriteLine($"Computer chose: {computersChoice}");
                DetermineWinner(userChoice, computersChoice);
                continuePlaying = PlayAgain();
            }

            Console.WriteLine("Thanks for playing!");
        }

        private static string ComputerChoice()
        {
            string[] options = { "Rock", "Paper", "Scissors" };
            Random numberGenerator = new Random();
            int randomIndex = numberGenerator.Next(options.Length);
            return options[randomIndex];
        }

        private static bool PlayAgain()
        {
            while (true)
            {
                Console.Write("Do you want to play again? (yes/no): ");
                string response = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (response == "yes" || response == "y")
                    return true;
                else if (response == "no" || response == "n")
                    return false;

                Console.WriteLine("Invalid input. Please enter yes or no.");
            }
        }

        private static void DetermineWinner(string userChoice, string computerChoice)
        {
            userChoice = userChoice.ToLower();
            computerChoice = computerChoice.ToLower();

            if (userChoice == computerChoice)
            {
                Console.WriteLine("It's a tie!");
            }
            else if ((userChoice == "rock" && computerChoice == "scissors") ||
                     (userChoice == "scissors" && computerChoice == "paper") ||
                     (userChoice == "paper" && computerChoice == "rock"))
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lost to the computer.");
            }
        }
    }
}
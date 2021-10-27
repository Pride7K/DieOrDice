using dieOrDice.General;
using dieOrDice.Models.Board;
using dieOrDice.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace dieOrDice
{
    class Program
    {

        private static void GetHowManyDices(out int returnValue)
        {
            string dieCount = String.Empty;
            Console.Write("How many dices do you want to play with ? ");
            dieCount = Console.ReadLine();
            Console.WriteLine("");

            var diffExpectedValue = int.TryParse(dieCount, out _);

            if (!diffExpectedValue)
            {
                while (!diffExpectedValue)
                {
                    Console.WriteLine("");
                    Console.Write("How many dices do you want to play with ? ");
                    dieCount = Console.ReadLine();
                    Console.WriteLine("");

                    diffExpectedValue = int.TryParse(dieCount, out _);
                }
            }

            returnValue = dieCount.ToInt();
        }

        private static void DisplayGreetings()
        {
            Console.WriteLine("Welcome to the automated Die");
            Console.WriteLine("");
        }

        private static bool isKeepPlaying()
        {
            List<string> _acceptedChoices = new List<string>()
            {
                "y",
                "n"
            };

            string choice = String.Empty;

            Console.Write("Roll the Die(s) (y) or (n): ");
            choice = Console.ReadLine();

            var diffExpectedValue = String.IsNullOrEmpty(choice) || choice.Length > 1 ||
               (choice.ToLower() != "y" && choice.ToLower() != "n");

            while (diffExpectedValue)
            {
                Console.Write("Roll the Die(s) (y) or (n): ");
                choice = Console.ReadLine();

                diffExpectedValue = String.IsNullOrEmpty(choice) || choice.Length > 1 ||
               (choice.ToLower() != "y" && choice.ToLower() != "n");

            }

            return choice.ToLower() == "y";
        }

        private async static void ShowSpinner()
        {
            Action spinner = async () =>
            {
                var counter = 0;
                for (int i = 0; i < 2; i++)
                {
                    switch (counter % 4)
                    {
                        case 0: Console.Write("/"); break;
                        case 1: Console.Write("-"); break;
                        case 2: Console.Write("\\"); break;
                        case 3: Console.Write("|"); break;
                    }
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    counter++;
                    Thread.Sleep(100);
                }

            };

            var task = new Task(spinner);

            task.RunSynchronously();

            await Task.WhenAll(task);
        }

        public static void HandleGame()
        {
            bool keepPlaying = true;

            DisplayGreetings();
            GetHowManyDices(out int dicesCount);

            var board = new Board(new Player(dicesCount), new Bot(dicesCount));

            while (keepPlaying)
            {
                keepPlaying = isKeepPlaying();
                if (!keepPlaying)
                    break;

                ShowSpinner();

                board.RollDice();
                Console.WriteLine(board.RoundWinner());
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine(board.MatchWinner());
        }

        static void Main(string[] args)
        {
            HandleGame();
        }
    }
}

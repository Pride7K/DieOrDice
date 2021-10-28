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
            Console.Write("How Many Dice Do You Want To Play With ? ");
            dieCount = Console.ReadLine();
            Console.WriteLine("");

            var differentExpectedValue = int.TryParse(dieCount, out _);

            if(differentExpectedValue && dieCount.ToInt() != default(int))
            {
                returnValue = dieCount.ToInt();
                return;
            }

            var isValueDifferentFromZero = dieCount.ToInt() != default(int);


            if (!differentExpectedValue || !isValueDifferentFromZero)
            {
                while (!differentExpectedValue || !isValueDifferentFromZero)
                {
                    Console.WriteLine("");
                    Console.Write("How Many Dice Do You Want To Play With ? ");
                    dieCount = Console.ReadLine();
                    Console.WriteLine("");

                    differentExpectedValue = int.TryParse(dieCount, out _);
                    if(differentExpectedValue)
                    {
                        isValueDifferentFromZero = dieCount.ToInt() != default(int);
                    }
                }
            }

            returnValue = dieCount.ToInt();
        }

        private static void DisplayGreetings()
        {
            Console.WriteLine("Welcome To The Automated Die");
            Console.WriteLine("");
        }

        public static void HandleGame()
        {
            DisplayGreetings();
            GetHowManyDices(out int dicesCount);

            var board = new Board(new Player(dicesCount), new Bot(dicesCount));
            board.PlayTheGame();
        }

        static void Main(string[] args)
        {
            HandleGame();
        }
    }
}

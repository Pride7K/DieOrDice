using dieOrDice.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dieOrDice.Models.Board
{
    public class Board
    {
        private Player _player { get; set; }
        private Bot _bot { get; set; }

        public Board(Player player, Bot bot)
        {
            if (player == null || bot == null)
            {
                throw new Exception("Give a player and bot");
            }
            _player = player;
            _bot = bot;
        }


        public void PlayTheGame()
        {
            while (isKeepPlaying())
            {
                this.RollDice();
                this.GiveRoundWinner();
            }

            this.GiveMatchWinner();
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

        private static bool isKeepPlaying()
        {
            List<string> _acceptedChoices = new List<string>()
            {
                "y",
                "n"
            };

            string choice = String.Empty;

            Console.Write("Roll the Die/Dice (y) or (n): ");
            choice = Console.ReadLine();

            var differentExpectedValue = String.IsNullOrEmpty(choice) || choice.Length > 1 ||
               (choice.ToLower() != "y" && choice.ToLower() != "n");

            while (differentExpectedValue)
            {
                Console.Write("Roll the Die/Dice (y) or (n): ");
                choice = Console.ReadLine();

                differentExpectedValue = String.IsNullOrEmpty(choice) || choice.Length > 1 ||
               (choice.ToLower() != "y" && choice.ToLower() != "n");

            }

            return choice.ToLower() == "y";
        }

        private void RollDice()
        {
            ShowSpinner();

            _player.GetDice();
            _bot.GetDice();

            if (_player.RoundValue > _bot.RoundValue)
            {
                _player.Points++;
                return;
            }

            _bot.Points++;

        }

        private void GiveRoundWinner()
        {

            var isPlayerWon = _player.RoundValue > _bot.RoundValue;
            var isBotWon = _bot.RoundValue > _player.RoundValue;

            var message = $"{_player._numberOfDice} Dice Was Rolled With The Sum Of {_player.RoundValue} And ";

            if (isPlayerWon)
            {
                message += $"You are the winner!";
            }
            else if (isBotWon)
            {
                message += $"Bot is the winner!";
            }
            else
            {
                message = $"Draw";
            }

            Console.WriteLine(message);
            Console.WriteLine("");
        }

        private void GiveMatchWinner()
        {

            var isPlayerWon = _player.Points > _bot.Points;
            var isBotWon = _bot.Points > _player.Points;

            var message = "The Final Winner Of The Match Is ";

            if (isPlayerWon)
            {
                message += $"You With {_player.Points} Points";
            }
            else if (isBotWon)
            {
                message += $"Bot With {_player.Points} Points";
            }
            else
            {
                message = $"Draw";
            }

            Console.WriteLine("");
            Console.WriteLine(message);
        }

    }
}

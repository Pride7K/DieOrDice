using dieOrDice.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void RollDice()
        {

            _player.GetDice();
            _bot.GetDice();

            if (_player.RoundValue > _bot.RoundValue)
            {
                _player.Points++;
                return;
            }

            _bot.Points++;

        }

        public string RoundWinner()
        {

            var isPlayerWon = _player.RoundValue > _bot.RoundValue;
            var isBotWon = _bot.RoundValue > _player.RoundValue;

            var message = $"{_player._numberOfDice} Dice was rolled with the sum of {_player.RoundValue} and ";

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

            return message;
        }

        public string MatchWinner()
        {

            var isPlayerWon = _player.Points > _bot.Points;
            var isBotWon = _bot.Points > _player.Points;

            var message = "The final winner of the match is ";

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

            return message;
        }

    }
}

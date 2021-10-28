using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dieOrDice.Models.Players
{
    public class Player : Abstract
    {
        public Player(int diceCount)
        {
            _numberOfDice = diceCount;
        }


        /// <summary>
        ///Being a casino owner, you’re trying to get the odds in your favor. 
        ///If you roll a specific number too many times, the casino (or our new automated statistics guy) 
        ///detects it and makes sure it gets harder to roll that number (of your choice) again.
        /// </summary>
        public override void GetDice()
        {
            // Retry logic is that in case of all numbers possible were rolled
            var retry = 0;
            while (IsRepeatedNumber(this.RoundValue) || this.RoundValue == default(int) || retry < 3)
            {
                base.GetDice();
                retry++;
            }

            if (retry >= 3)
            {
                this._rolledDices = new List<int>();
                retry = 0;
            }

            this._rolledDices.Add(this.RoundValue);
        }

        private bool IsRepeatedNumber(int result)
        {
            return _rolledDices.Where(t => t == result).Count() > 0;
        }
    }
}

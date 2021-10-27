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

        public override void GetDice()
        {
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

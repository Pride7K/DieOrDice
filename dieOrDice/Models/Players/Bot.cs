using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dieOrDice.Models.Players
{
    public class Bot : Abstract
    {
        public Bot(int diceCount)
        {
            _numberOfDice = diceCount;
        }

        public override void GetDice()
        {
            base.GetDice();
        }
    }
}

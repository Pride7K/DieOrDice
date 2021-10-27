using dieOrDice.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dieOrDice.Models
{
    public abstract class Abstract
    {
        public List<int> _rolledDices = new List<int>();
        public int _numberOfDice { get; set; }
        public int RoundValue { get; set; }
        public int Points { get; set; }
        public virtual void GetDice()
        {
            var result = default(int);

            for (var die = 0; die < this._numberOfDice; die++)
            {
                var randomNumber = Utils.GetRandomDiceValue();
                result += randomNumber;
            }

            this.RoundValue = result;
        }
    }
}

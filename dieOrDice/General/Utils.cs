using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dieOrDice.General
{
    public static class Utils
    {

        public static int ToInt(this String value)
        {
            return int.Parse(value);
        }

        public static string ToHumanizeWord(this int value)
        {
            return value.ToWords(System.Globalization.CultureInfo.GetCultureInfo("en-US")).Titleize();
        }

        public static int GetRandomDiceValue()
        {
            return new Random().Next(1, 6);
        }

    }
}

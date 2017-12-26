using System.Globalization;
using UnityEngine;

namespace Assets
{

    public class NumberFormatter
    {
        public string Format(float number)
        {
            if (number >= 1e3 && number < 1e6)
            {
                return (number / 1e3).ToString("0.00") + " K";
            }
            if (number >= 1e6 && number < 1e9)
            {
                return (number / 1e6).ToString("0.00") + " M";
            }
            if (number >= 1e9 && number < 1e12)
            {
                return (number / 1e9).ToString("0.00") + " B";
            }
            if (number >= 1e12 && number < 1e15)
            {
                return (number / 1e12).ToString("0.00") + " T";
            }
            if (number >= 1e15 && number < 1e18)
            {
                return (number / 1e15).ToString("0.00") + " q";
            }
            if (number >= 1e18 )
            {
                return (number / 1e18).ToString("0.00") + " Q";
            }

            return  number.ToString("0");
        }
    }
}
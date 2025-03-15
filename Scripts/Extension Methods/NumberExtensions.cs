using System.Linq;
using UnityEngine;

namespace Project.ExtensionMethod
{
    public static class NumberExtensions
    {
        public static int NonRepeatingRandom(this System.Random random, int minValue, int maxValue, ref int lastRandomValue)
        {
            int randomValue;
            do
            {
                randomValue = random.Next(minValue, maxValue + 1);
            } while (randomValue == lastRandomValue);

            lastRandomValue = randomValue;
            return randomValue;
        }

        public static int ToIntAndMultiplyBy1000(this float value)
        {
            return (int)(value * 1000);
        }

        public static int ExtractNumber(this string input)
        {
            string numberString = new string(input.Where(char.IsDigit).ToArray());
            return int.Parse(numberString);
        }
    }
}

using UnityEngine;

namespace Project.Tools.Help
{
    public static class RandomPossibilities
    {
        /// <summary>
        /// Example: If 0.75f then 75% possibility
        /// </summary>
        /// <returns></returns>
        public static bool IsLessThan(float value)
        {
            return Random.value < value;
        }

        /// <summary>
        /// Example: If 0.75f then 25% possibility
        /// </summary>
        /// <returns></returns>
        public static bool IsBiggerThan(float value)
        {
            return Random.value > value;
        }

        /// <summary>
        /// 75% possibility
        /// </summary>
        /// <returns></returns>
        public static bool IsLessThanSeventyFivePercent()
        {
            return Random.value < 0.75f;
        }

        /// <summary>
        /// 50% possibility
        /// </summary>
        /// <returns></returns>
        public static bool IsLessThanFiftyPercent()
        {
            return Random.value < 0.5f;
        }

        /// <summary>
        /// 25% possibility
        /// </summary>
        /// <returns></returns>
        public static bool IsLessThanTwentyFivePercent()
        {
            return Random.value < 0.25f;
        }

        /// <summary>
        /// 10% possibility
        /// </summary>
        /// <returns></returns>
        public static bool IsLessThanTenPercent()
        {
            return Random.value < 0.1f;
        }

        /// <summary>
        /// 90% possibility
        /// </summary>
        /// <returns></returns>
        public static bool IsLessThanNinetyPercent()
        {
            return Random.value < 0.9f;
        }
    }
}

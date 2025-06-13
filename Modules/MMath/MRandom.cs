using System;

namespace Mighty
{
    public static class MRandom
    {

        /// <summary>
        /// Get Random integer value from, 0 to int.MaxValue
        /// </summary>
        /// <returns>Returns random number in 0 to 2147483647</returns>
        public static int GetRandomInt()
        {
            Random random = new Random();

            int result = random.Next();

            return result;
        }

        /// <summary>
        /// Get Random integer from 0 to 'Max' value
        /// </summary>
        /// <param name="max"></param>
        /// <returns>Returns random number in 0 to Max</returns>
        public static int GetRandomInt(int max)
        {
            Random random = new Random();

            int result = random.Next(max);

            return result;
        }

        /// <summary>
        /// Get Random integer from 'Min' to 'Max'
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Returns random number in Min to Max</returns>
        public static int GetRandomInt(int min, int max)
        {
            Random random = new Random();

            int result = random.Next(min, max);

            return result;
        }
    }
}
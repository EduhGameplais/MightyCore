using System;
using System.Data.SqlTypes;
using System.Security.AccessControl;
using System.IO;
using System.Net;
using System.Linq;

namespace Mighty
{
    /// <summary>
    /// Mighty Math class.
    /// </summary>
    public class Mathf
    {
        #region Clamp

        /// <summary>
        /// Returns value, if value are greater than 1, return 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Return a float between 0 and 1</returns>
        public static float Clamp01(float value)
        {
            return InternalClamp(value, 0, 1);
        }
        
        /// <summary>
        /// Returns value, if value are greater than max, return max | if value are lower than 0, return 0
        /// </summary>
        /// <param name="value"></param>
        /// <param name="max"></param>
        /// <returns>Returns float between 0 and max</returns>
        public static float Clamp(float value, float max)
        {
            return InternalClamp(value, 0, max);
        }

        /// <summary>
        /// Returns value, if value are lower than min, return min | if value are greater than max, return max
        /// </summary>
        /// <param name="value"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns>Return a float between min and max</returns>
        public static float Clamp(float value, float max, float min)
        {
            return InternalClamp(value, min, max);
        }

        private static float InternalClamp(float value, float min, float max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            else
            {
                return value;
            }
        }

        #endregion
        #region Average
        
        /// <summary>
        /// Returns average of value1 and value2
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns>Returns a float with average of value1 and value2</returns>
        public static float Average(float value1, float value2)
        {
            return InternalAverage(new[] { value1, value2 });
        }
        /// <summary>
        /// Return average of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns>Return a float with average of values</returns>
        public static float Average(float[] values)
        {
            return InternalAverage(values);
        }
        
        private static float InternalAverage(float[] values)
        {
            float totalSum = 0;

            foreach (var value in values)
            {
                totalSum += value;
            }

            totalSum /= values.Length;
            return totalSum;
        }

        #endregion
        #region Higher

        /// <summary>
        /// Retorns higher value between a and b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Returns a float</returns>
        public static float Higher(float a, float b)
        {
            return InternalHigher(new[] { a, b });
        }

        /// <summary>
        /// Returns higher value in array of floats
        /// </summary>
        /// <param name="values"></param>
        /// <returns>Returns higher value</returns>
        public static float Higher(float[] values)
        {
            return InternalHigher(values);
        }
        
        private static float InternalHigher(float[] values)
        {
            float higher = 0;

            foreach (var value in values)
            {
                if (higher <= value)
                {
                    higher = value;
                }
            }

            return higher;
        }

        #endregion
        #region Lower

        /// <summary>
        /// return lower float
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>return lower float</returns>
        public static float Lower(float a, float b)
        {
            return InternalLower(new[] { a, b });
        }

        /// <summary>
        /// return lower float
        /// </summary>
        /// <param name="values"></param>
        /// <returns>return lower float</returns>
        public static float Lower(float[] values)
        {
            return InternalLower(values);
        }
        
        private static float InternalLower(float[] values)
        {
            float lower = float.MaxValue;
            
            foreach(var value in values)
            {
                if (value <= lower)
                {
                    lower = value;
                }
            }

            return lower;
        }

        #endregion
        #region Equivalent

        /// <summary>
        /// Verify if a and b are equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool Equivalent(object a, object b)
        {
            return InternalEquivalent(new[] {a,b});
        }

        /// <summary>
        /// verify if array of objects have every object equals.
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static bool Equivalent(object[] objects)
        {
            return InternalEquivalent(objects);
        }
        
        private static bool InternalEquivalent(object[] objects)
        {
            if (objects.Length == 0)
            {
                return true;
            }

            object first = objects[0];
            for (int i = 1; i < objects.Length; i++)
            {
                if (objects[i] != first)
                {
                    return false;
                }
            }

            return true;
        }

        

        #endregion
        #region CalcVolume

        private static float InternalCalcVolumeByMaster(float master, float volume, float multiplier)
        {
            if (master.Equals(0) || volume.Equals(0)) return 0;

            float result = 0;

            result = Average(master, volume) * multiplier;

            return result;

        }

        #endregion
        #region Potence
        public static float Potence(float value, float ex)
        {
            return InternalPotence(ex, value);
        }

        private static float InternalPotence(float ex, float value)
        {
            return (float)System.Math.Pow(value, ex);
        }

        #endregion
        #region Rad
        public static float Rad(float x)
        {
            return InternalRad(x);
        }

        public static float[] Rad(float[] xs)
        {
            float[] results = new float[xs.Length];
            foreach(var x in xs)
            {
                results.Append(InternalRad(x));
            }
            return results;
        }

        private static float InternalRad(float x)
        {
            return (float)System.Math.Sqrt(x);
        }
        #endregion
    }
}
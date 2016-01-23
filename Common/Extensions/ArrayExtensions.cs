using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Extension method to fetch the value from array based on index
        /// if index is greater than length return the default of the type being expected
        /// else  cast the found value at index and return it
        /// </summary>
        /// <typeparam name="T">type of input array</typeparam>
        /// <typeparam name="R">type of value to be found</typeparam>
        /// <param name="inputArray">input array</param>
        /// <param name="index">index of the value to be found</param>
        /// <returns>value at the index or default value of return type</returns>
        public static R CheckIndexAndGetValue<T, R>(this T[] inputArray, int index)
        {
            if (inputArray.Length > index)
            {
                try
                {
                    return (R)Convert.ChangeType(inputArray[index], typeof(R));
                }
                catch
                {
                    return default(R);
                }
            }
            else
                return default(R);
        }
    }
}

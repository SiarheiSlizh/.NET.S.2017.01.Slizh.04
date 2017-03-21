using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_4
{
    /// <summary>
    /// This class works with numbers.
    /// </summary>
    public static class WorkingWithNumbers
    {
        #region NextBiggerNumber
        /// <summary>
        /// This method finds next bigger number, which consists of this digits.
        /// </summary>
        /// <param name="number">Initial number for which is found next bigger number.</param>
        /// <returns></returns>
        public static int NextBiggerNumber(int number)
        {
            if (number < 0)
                throw new ArgumentException();

            string str = number.ToString();
            string substr = GetSubstring(str);

            if (string.IsNullOrEmpty(substr)) return -1;
            else
                return int.Parse(str.Substring(0, str.Length - substr.Length) + PartOfNumber(substr));
        }

        /// <summary>
        /// This Method finds substring where we neet to replace elements.
        /// </summary>
        /// <param name="str">String which contains predetermained number.</param>
        /// <returns>Substring if it is found else null.</returns>
        private static string GetSubstring(string str)
        {
            int i = str.Length - 1;
            for (; i > 0; i--)
                if (str[i - 1] < str[i])
                    return str.Substring(i - 1);
            return null;
        }

        /// <summary>
        /// This method makes second part of number.
        /// </summary>
        /// <param name="substr">Second part of string.</param>
        /// <returns>Modified string.</returns>
        private static string PartOfNumber(string substr)
        {
            char[] partStr = substr.ToArray();
            Array.Sort(partStr, 1, partStr.Length - 1);
            int index = Array.FindIndex(partStr, p => p > partStr[0]);

            ChangeElements(partStr, index);

            return new string(partStr);
        }

        /// <summary>
        /// This Method replaces two elements in Array: 0 and index.
        /// </summary>
        /// <param name="partStr">Array of elements whuch are the second part of number.</param>
        /// <param name="index">Index which we replace with 0 elemets of array.</param>
        private static void ChangeElements(char[] partStr, int index)
        {
            char buf = partStr[index];
            partStr[index] = partStr[0];
            partStr[0] = buf;
        }
        #endregion

        #region NewtonMethod
        /// <summary>
        /// This method calculates the root of n-degree of number.
        /// </summary>
        /// <param name="number">Digit for which the method finds the root.</param>
        /// <param name="n">Degree of number.</param>
        /// <param name="eps">Predetermained occuracy.</param>
        /// <returns></returns>
        public static double NewtonMethod(double number, int n, double eps)
        {
            if (n < 0)
                throw new ArgumentException();

            if ((n % 2 == 0  && number < 0) || eps < 0)
                throw new ArithmeticException();

            double x = 1;
            while (true)
            {
                double nx = ((n - 1) * x + number / Math.Pow(x, n - 1)) / n;
                if (Math.Abs(x - nx) < eps) return x;
                x = nx;
            }
        }
        #endregion
    }
}
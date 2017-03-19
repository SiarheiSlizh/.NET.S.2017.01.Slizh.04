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

            string num = number.ToString();
            byte[] arrDigit = new byte[num.Length];

            for (int j = num.Length - 1; j > -1; j--)
            {
                arrDigit[j] = (byte)(number % 10);
                number /= 10;
            }

            byte[] arrPartDigit = null;
            byte buf = byte.MinValue;

            int i = num.Length - 1;
            for (; i > 0; i--)
            {
                if (arrDigit[i - 1] < arrDigit[i])
                {
                    buf = arrDigit[i - 1];
                    arrPartDigit = new byte[num.Length - i];
                    Array.Copy(arrDigit, i, arrPartDigit, 0, arrPartDigit.Length);
                    Array.Sort(arrPartDigit);
                    break;
                }
            }

            if (i == 0) return -1;
            else
            {
                for (int j = 0; j < arrPartDigit.Length; j++)
                    if (arrPartDigit[j] > buf)
                    {
                        arrDigit[i - 1] = arrPartDigit[j];
                        arrPartDigit[j] = buf;
                        Array.Copy(arrPartDigit, 0, arrDigit, i, arrPartDigit.Length);
                        break;
                    }

                return int.Parse(string.Concat(arrDigit.Take(num.Length)));
            }
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
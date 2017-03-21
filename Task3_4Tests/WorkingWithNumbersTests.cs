using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_4;

namespace Task3_4Tests
{
    [TestFixture]
    public class WorkingWithNumbersTests
    {
        #region NextBiggerNumber

        [TestCase(-4)]
        public void NextBiggerNumber_ArgumentException(int number)
        {
            Assert.Throws<ArgumentException>(() => WorkingWithNumbers.NextBiggerNumber(number));
        }
        

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(0, ExpectedResult = -1)]
        public int NextBiggerNumber_PositiveTests(int number)
        {
            return WorkingWithNumbers.NextBiggerNumber(number);
        }
        #endregion
        #region NewtonMethod

        [TestCase(3,-2,0.01)]
        public void NewtonMethod_ArgumentException(double number, int n, double eps)
        {
            Assert.Throws<ArgumentException>(() => WorkingWithNumbers.NewtonMethod(number, n, eps));
        }


        [TestCase(4, 2, -0.1)]
        [TestCase(-4, 2, 0.01)]
        [TestCase(3, 3, -0.1)]
        public void NewtonMethod_ArithmeticException(double number, int n, double eps)
        {
            Assert.Throws<ArithmeticException>(() => WorkingWithNumbers.NewtonMethod(number, n, eps));
        }


        [TestCase(30.25, 2, 0.0000000001, ExpectedResult = 5.5)]
        [TestCase(166.375, 3, 0.000000000000001, ExpectedResult = 5.5)]
        [TestCase(69.934528, 3, 0.0000000000000001, ExpectedResult = 4.12)]
        public double NewtonMethod_PositiveTests(double number, int n, double eps)
        {
            return WorkingWithNumbers.NewtonMethod(number, n, eps);
        }
        #endregion
    }
}

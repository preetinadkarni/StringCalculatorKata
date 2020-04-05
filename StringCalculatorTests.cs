using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Test_Step1_InputString_ReturnsNumber()
        {
            StringCalculator sc = new StringCalculator();
            Assert.AreEqual(sc.Add(""), 0);
        }

        [Test]
        [TestCase("1")]
        [TestCase("3")]
        public void Test_Step2_InputANumber_ReturnsThatNumber(string value)
        {
            StringCalculator sc = new StringCalculator();
            Assert.AreEqual(Convert.ToInt32(value), sc.Add(value));
        }

        [Test]
        [TestCase("1,2",ExpectedResult = 3)]
        [TestCase("3,5",ExpectedResult = 8)]
        public int Test_Step3_InputTwoNumbers_ReturnsSumOfThoseNumbers(string value)
        {
            StringCalculator sc = new StringCalculator();
            return sc.Add(value);
        }

        [Test]
        [TestCase("1, 2, 3", ExpectedResult = 6)]
        [TestCase("3,5,3,9", ExpectedResult = 20)]
        public int Test_Step4_InputMultipleNumbers_ReturnsSumOfThoseNumbers(string value)
        {
            StringCalculator sc = new StringCalculator();
            return sc.Add(value);
        }

        [Test]
        [TestCase("1,2\n3", ExpectedResult = 6)]
        [TestCase("3\n5\n3,9", ExpectedResult = 20)]
        public int Test_Step5_InputNumbersInStringWithCommasOrNewLine_ReturnsSumOfThoseNumbers(string value)
        {
            StringCalculator sc = new StringCalculator();
            return sc.Add(value);
        }

        [Test]
        [TestCase("//;\n1;2", ExpectedResult = 3)]
        public int Test_Step6_InputSupportDifferentDelimiters_ReturnsSumOfThoseNumbers(string value)
        {
            StringCalculator sc = new StringCalculator();
            return sc.Add(value);
        }

        [Test]
        [TestCase("-1,2,-3")]
        public void Test_Step7_InputNegativeNumbers_ThrowsException(string value)
        {
            StringCalculator sc = new StringCalculator();

            var ex = Assert.Throws<ArgumentException>(() => sc.Add(value));
            Assert.AreEqual("Negatives not allowed: -1, -3", ex.Message);
        }

        [Test]
        [TestCase("1000,1001,2", ExpectedResult = 2)]
        public int Test_Step8_InputGreaterThan1000IgnoredInSum(string value)
        {
            StringCalculator sc = new StringCalculator();
            return sc.Add(value);
        }

        [Test]
        [TestCase("//[***]\n1***2***3", ExpectedResult = 6)]
        public int Test_Step9_InputLongDelimiters_ReturnsSumOfThoseNumbers(string value)
        {
            StringCalculator sc = new StringCalculator();
            return sc.Add(value);
        }

        [Test]
        [TestCase("//[*][%]\n1*2%3", ExpectedResult = 6)]
        public int Test_Step10_InputAllowMultipleDelimiters_ReturnsSumOfThoseNumbers(string value)
        {
            StringCalculator sc = new StringCalculator();
            return sc.Add(value);
        }

        [Test]
        [TestCase("//[***][#][%]\n1***2#3%4", ExpectedResult = 10)]
        public int Test_Step11_InputAllowMultipleDelimitersLongerThanOneCharacter_ReturnsSumOfThoseNumbers(string value)
        {
            StringCalculator sc = new StringCalculator();
            return sc.Add(value);
        }

        [Test]
        [TestCase("//[*1*][%]\n1*1*2%3", ExpectedResult = 6)]
        public int Test_Step12_InputAllowMultipleDelimitersWithNumbers_ReturnsSumOfThoseNumbers(string value)
        {
            StringCalculator sc = new StringCalculator();
            return sc.Add(value);
        }

    }
}
using SeleniumProject1.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject1.tests
{
    [Parallelizable]
    public class AddSubtractTest : BaseTest
    {
        [TestCase(9,7)]
        public void Addition(double a, double b)
        {
            string str1 = a.ToString();
            string str2 = b.ToString();

            string result = homePageStep.Add(str1, str2);

            Assert.AreEqual(a + b, double.Parse(result), "Result is incorrect");
            ReportLog.Pass("Addition of " + a + " and " + b + " is: " + result);
        }

        [TestCase(9,7)]
        public void Subtraction(double a, double b)
        {
            string str1 = a.ToString();
            string str2 = b.ToString();

            string result = homePageStep.Subtract(str2 , str1);

            Assert.AreEqual(a - b, double.Parse(result), "Result is incorrect");
            ReportLog.Pass("Subtraction of " + a + " and " + b + " is: " + result);
        }
    }
}

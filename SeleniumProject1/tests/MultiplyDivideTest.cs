using SeleniumProject1.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject1.tests
{
    [Parallelizable]
    public class MultiplyDivideTest : BaseTest
    {
        [TestCase(9, 7)]
        public void Multiply(double a , double b)
        {
            string str1 = a.ToString();
            string str2 = b.ToString();

            string result = homePageStep.Multiply(str1, str2);
            Assert.AreEqual(a * b, double.Parse(result), "Result is incorrect");
            ReportLog.Pass("Multiplication of " + a + " and " + b + " is: " + result);
        }

        [TestCase(9, 7)]
        public void Divide(double a , double b)
        {

            string str1 = a.ToString();
            string str2 = b.ToString();

            string result = homePageStep.Divide(str1, str2);
            Assert.AreEqual(a / b, float.Parse(result), "Result is incorrect");
            ReportLog.Pass("Division of " + a + " and " + b + " is: " + result);
        }
    }
}

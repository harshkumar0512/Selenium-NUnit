using OpenQA.Selenium;
using SeleniumProject1.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject1.steps
{
    public class HomePageStep : HomePage
    {
        public HomePageStep(IWebDriver driver) : base(driver)
        {
        }

        public string Add(string a, string b)
        {
            EnterNumber(a);
            Click(AddOperator);
            EnterNumber(b);
            return GetElementText(Output);
        }

        public string Subtract(string a, string b)
        {
            EnterNumber(a);
            Click(SubtractOperator);
            EnterNumber(b);
            return GetElementText(Output);
        }

        public string Multiply(string a, string b)
        {
            EnterNumber(a);
            Click(MultiplyOperator);
            EnterNumber(b);
            return GetElementText(Output);
        }

        public string Divide(string a, string b)
        {
            EnterNumber(a);
            Click(DivisionOperator);
            EnterNumber(b);
            return GetElementText(Output);
        }
    }
}

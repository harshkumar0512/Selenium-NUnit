using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject1.pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        protected By Output = By.Id("sciOutPut");
        protected By AddOperator = By.XPath("//span[text() = '+']");
        protected By SubtractOperator = By.XPath("//span[text() = '–']");
        protected By MultiplyOperator = By.XPath("//span[text() = '×']");
        protected By DivisionOperator = By.XPath("//span[text() = '/']");
        protected By NegateOperator = By.XPath("//span[text() = '±']");
        protected By EqualButton = By.XPath("//span[text() = '=']");
        protected By Button(char ch) => By.XPath("//span[text() = '" + ch + "']");
        public void EnterNumber(string num)
        {
            for(int i = 0; i < num.Length; i++)
            {
                char c = num[i];
                if (!c.Equals('-')) 
                {
                    Click(Button(c));
                }
            }
            if(num.Contains('-'))
            {
                Click(NegateOperator);
            }
        }

    }
}

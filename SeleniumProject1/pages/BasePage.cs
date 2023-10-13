using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject1.pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        public void WaitForPageToLoad()
        {
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public void validateElementTitle(By ele)
        {
            WaitForPageToLoad();
            wait.Until(driver =>
            {
                try
                {
                    IWebElement element = driver.FindElement(ele);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

        }

        public void Click(By element)
        {
            IWebElement el = driver.FindElement(element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", el);
           // el.Click();
        }

        public void scrollIntoViewAndClick(By element)
        {
            IWebElement el = driver.FindElement(element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.Click();
        }

        public void scrollIntoView(By element)
        {
            IWebElement el = driver.FindElement(element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", el);
        }

        public void scrollIntoViewAndInput(By element, String input)
        {
            IWebElement el = driver.FindElement(element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.SendKeys(input);
        }

        public void WaitForElementToBeVisible(By element)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public void WaitForElementToBeClickable(By ele)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ele));
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }

        }

        public string GetElementText(By element)
        {
            IWebElement el = driver.FindElement(element);
            return el.Text.ToString();
        }
    }
}

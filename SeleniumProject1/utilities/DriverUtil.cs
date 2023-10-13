using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject1.utilities
{
    public class DriverUtil
    {
        private IWebDriver driver;

        public IWebDriver GetDriver(string browser)
        {
            try
            {
                driver = SetDriver(browser);
            }
            catch(Exception e) 
            { 
                Assert.Fail(e.Message);
            }
            return driver;
        }

        private IWebDriver SetDriver(string browser) 
        {
            switch(browser.ToLower())
            {
                case "chrome":
                    driver = InitChromeDriver();
                    ReportLog.Pass("Chrome initialized successfully");
                    break;

                case "firefox":
                    driver = InitFirefoxDriver();
                    ReportLog.Pass("Firefox initislized successfully");
                    break;
                default:
                    Assert.Fail("Invalid Browser");
                    break;
                
            }
            driver.Manage().Window.Maximize();
            return driver;
        }

        private IWebDriver InitChromeDriver() => new ChromeDriver();

        private IWebDriver InitFirefoxDriver()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.Host = "::1";
            return new FirefoxDriver();
        }
    }
}

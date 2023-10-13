using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumProject1.steps;
using SeleniumProject1.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject1.tests
{
    public class BaseTest
    {
        private IWebDriver driver;
        private DriverUtil driverUtil;
        private const string URL = "https://www.calculator.net/";
        private const string BROWSER = "Chrome";
        public HomePageStep homePageStep;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            driverUtil = new DriverUtil();
            ExtentTestManager.CreateParentTest(GetType().Name);
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentService.GetExtent().Flush();
        }

        [SetUp]
        public void Setup()
        {
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
            driver = driverUtil.GetDriver(BROWSER);
            driver.Navigate().GoToUrl(URL);
            homePageStep = new HomePageStep(driver);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                    ? ""
                    : string.Format("<pre>{0}<pre>", TestContext.CurrentContext.Result.Message);
                var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}<pre>", TestContext.CurrentContext.Result.StackTrace);
                switch (status)
                {
                    case TestStatus.Failed:
                        ReportLog.Fail("Test Failed");
                        ReportLog.Fail(errorMessage);
                        ReportLog.Fail(stackTrace);
                        ReportLog.Fail("Screenshot", CaptureScreenshot(TestContext.CurrentContext.Test.Name));
                        break;
                    case TestStatus.Passed:
                        ReportLog.Pass("Test Passed");
                        break;
                    case TestStatus.Skipped:
                        ReportLog.Skip("Test Skipped");
                        break;
                    default: 
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }
            finally
            {
                driver.Quit();
            }
        }

        public MediaEntityModelProvider CaptureScreenshot(string name)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,name).Build();
        }

    }
}

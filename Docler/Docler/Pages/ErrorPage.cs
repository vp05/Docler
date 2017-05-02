using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowParallelTest.Pages
{
    [Binding]
    class ErrorPage
    {

        public static By ERROR_MENU_BUTTON = By.CssSelector("a#error");
        public static By ERROR_MENU_BUTTON_CONTAINER = By.XPath("//*/a[@id='error']/../../li[@class='active']");
        public static By ERROR_H1 = By.CssSelector("h1");
        public static By ERROR_P = By.XPath("//*/p[text()='Through the magic of digital telecommunications, your wrong credential is now winging its way to the maintainer.']");
        public static By ERROR_I = By.CssSelector("i");

        private IWebDriver _driver;
        private ExtentTest _test;
        private CommonPage _commonPage;

        public ErrorPage(IWebDriver driver, ExtentTest test, CommonPage commonPage)
        {
            _driver = driver;
            _commonPage = commonPage;
        }

        public Boolean isPageLoadedProperly()
        {
            IWebElement errorH1;
            String errorH1Text = "";

            Thread.Sleep(2000);

            errorH1 = _commonPage.findElement(ERROR_H1);
            errorH1Text = errorH1.Text; //has to be li.active

            if (errorH1 != null && errorH1Text.Equals("404 Error: File not found :-("))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkHTTPResponse(int exptectedResponse)
        {
            return isPageLoadedProperly();
        }

    }
}
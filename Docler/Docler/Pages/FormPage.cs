using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowParallelTest.Pages
{
    [Binding]
    class FormPage
    {
        public static By FORM_MENU_BUTTON = By.CssSelector("a#form");
        public static By FORM_MENU_BUTTON_CONTAINER = By.XPath("//*/a[@id='form']/../../li[@class='active']");
        public static By INPUT_BOX = By.CssSelector("input#hello-input");
        public static By SUBMIT_BUTTON = By.CssSelector("span.input-group-btn");
        public static By HELLO_TEXT = By.CssSelector("h1#hello-text");

        private IWebDriver _driver;
        private ExtentTest _test;
        private CommonPage _commonPage;

        public FormPage(IWebDriver driver, ExtentTest test, CommonPage commonPage)
        {
            _driver = driver;
            _test = test;
            _commonPage = commonPage;
        }

        public Boolean isPageLoadedProperly()
        {
            IWebElement formMenuButtonContainer;
            String formButtonContainerClass = "";

            Thread.Sleep(2000);

            formMenuButtonContainer = _commonPage.findElement(FORM_MENU_BUTTON_CONTAINER);
            formButtonContainerClass = formMenuButtonContainer.GetAttribute("class"); //has to be li.active

            if (formMenuButtonContainer != null && formButtonContainerClass.Equals("active"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean writeTextIntoElement(String text)
        {
            IWebElement webElement = _commonPage.findElement(INPUT_BOX);
            if(webElement == null)
            {
                _test.Log(Status.Fail, "Couldn't find webElement.");
                return false;
            }
            Thread.Sleep(1000);
            webElement.SendKeys(text);
            //webElement = _commonPage.findElement(INPUT_BOX);
            //if(webElement == null || !webElement.Text.Equals(text))
            //{
            //    _test.Log(Status.Fail, "Couldn't find webElement or the expected test does not equal:\nExpected: " + text + "\nActual: " + webElement.Text);
            //    return false;
            //}
            _test.Log(Status.Pass, "Writing text " + text + " into input box was successful.");            
            return true;
        }

        public Boolean checkHelloText(String helloText)
        {
            IWebElement webElement = _commonPage.findElement(HELLO_TEXT);
            if(webElement == null)
            {
                _test.Log(Status.Fail, "Couldn't find webElement.");
                return false;
            }
            if (!webElement.Text.Equals(helloText))
            {
                _test.Log(Status.Fail, "Couldn't find webElement or the expected test does not equal:\nExpected: " + helloText + "\nActual: " + webElement.Text);
                return false;
            }
            _test.Log(Status.Pass, helloText + " is displayed as it's expected.");
            return true;
        }

    }
}
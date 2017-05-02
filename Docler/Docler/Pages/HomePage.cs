using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowParallelTest.Pages
{
    [Binding]
    class HomePage
    {

        public static By HOME_MENU_BUTTON = By.CssSelector("a#home");
        public static By HOME_MENU_BUTTON_CONTAINER = By.XPath("//*/a[@id='home']/../../li[@class='active']");
        public static By WELCOME_HEADER = By.CssSelector("div.ui-test > h1");
        public static By DESCRIPTION = By.CssSelector("p.lead");

        private IWebDriver _driver;
        private ExtentTest _test;
        private CommonPage _commonPage;

        public HomePage(IWebDriver driver, ExtentTest test, CommonPage commonPage)
        {
            _driver = driver;
            _commonPage = commonPage;
        }

        public Boolean isPageLoadedProperly()
        {
            IWebElement homeMenuButtonContainer;
            IWebElement homePageH1;
            String homeButtonContainerClass = "";
            String homePageH1Text = "";

            Thread.Sleep(2000);

            homeMenuButtonContainer = _commonPage.findElement(HomePage.HOME_MENU_BUTTON_CONTAINER);
            homeButtonContainerClass = homeMenuButtonContainer.GetAttribute("class"); //has to be li.active

            homePageH1 = _commonPage.findElement(HomePage.WELCOME_HEADER);
            homePageH1Text = homePageH1.Text;

            if (homeMenuButtonContainer != null && homePageH1 != null && homeButtonContainerClass.Equals("active") && homePageH1Text.Equals("Welcome to the Docler Holding QA Department"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

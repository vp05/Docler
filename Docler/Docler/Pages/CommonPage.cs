using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowParallelTest.Pages
{
    [Binding]
    class CommonPage
    {
        public static By TITLE = By.XPath("//*/title");
        public static By LOGO = By.CssSelector(".img-responsive");
        //public static By LOGO = By.CssSelector("img.dh_logo");
        public static By uiTestingSiteButton = By.CssSelector("a.navbar-brand");

        private IWebDriver _driver;
        private ExtentTest _test;
        private HomePage _homePage;
        private FormPage _formPage;
        private ErrorPage _errorPage;

        public CommonPage(IWebDriver driver, ExtentTest test)
        {
            _driver = driver;
            _test = test;
            //_extent = ExtentManager.Instance;
            //_test = test;
            //_scenarioContext = scenarioContext;
            _homePage = new HomePage(_driver, _test, this);
            _formPage = new FormPage(_driver, _test, this);
            _errorPage = new ErrorPage(_driver, _test, this);

        }

        public Boolean navigateTo(String url)
        {

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
                    _driver.Navigate().GoToUrl(url);
                    Console.WriteLine("Navigation was successful on the " + (i + 1) + ". try.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Navigation failed on the " + (i + 1) + ". try.");
                    _driver.Quit();
                    //_driver.Close();
                    var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembl‌​y().Location);
                    ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService(driverDir, "chromedriver.exe");
                    _driver = new ChromeDriver(chromeService);

                }

            }
            //_driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
            //_driver.Navigate().GoToUrl(url);

            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));

            IWebElement homeMenuButton;
            IWebElement homePageH1;
            String homeButtonClass = "";
            String homePageH1Text = "";
            //try
            //{
            //    homeMenuButton = _driver.FindElement(By.CssSelector("li.active > a#home"));
            //    homeMenuButton = _driver.FindElement(By.XPath("//*/a[@id='home']/../../li[@class='active']"));
            //    homeButtonClass = homeMenuButton.GetAttribute("class"); //has to be li.active
            //    homePageH1 = _driver.FindElement(By.CssSelector("div.ui-test > h1"));
            //    homePageH1Text = homePageH1.Text;
            //}
            //catch (Exception ex)
            //{
            //    homeMenuButton = null;
            //    homePageH1 = null;
            //}

            homeMenuButton = this.findElement(HomePage.HOME_MENU_BUTTON_CONTAINER);
            homeButtonClass = homeMenuButton.GetAttribute("class"); //has to be li.active

            homePageH1 = _driver.FindElement(HomePage.WELCOME_HEADER);
            homePageH1Text = homePageH1.Text;
            if (homeMenuButton != null && homePageH1 != null && homeButtonClass.Equals("active") && homePageH1Text.Equals("Welcome to the Docler Holding QA Department"))
            {
                _test.Log(Status.Pass, "Passed");
                return true;
            }
            else
            {
                _test.Log(Status.Fail, "Failed");
                return false;
            }
            //homeMenuButton = this.findElement(HomePage.HOME_MENU_BUTTON);

        }



        //public Boolean navigateToPage(Table table)
        //public Boolean navigateToPage(IList<dynamic> pages)
        public Boolean navigateToPage(String page)
        {
            Boolean b = false;
            //dynamic data = table.CreateDynamicInstance();
            IWebElement menuButton;
            String str = page;
            //foreach(var page in pages)
            //{
            //    //str = "Bazdmeg, hogy nincs minden objecten ToString()";
            //    str = page.pages;
            //}
            if (str.Equals("Home"))
            {
                menuButton = _driver.FindElement(HomePage.HOME_MENU_BUTTON);
                menuButton.Click();
                Thread.Sleep(2000);
                b = _homePage.isPageLoadedProperly();
            }
            else if (str.Equals("Form"))
            {
                menuButton = _driver.FindElement(FormPage.FORM_MENU_BUTTON);
                menuButton.Click();
                Thread.Sleep(2000);
                b = _formPage.isPageLoadedProperly();
            }
            else if (str.Equals("Error"))
            {
                menuButton = _driver.FindElement(ErrorPage.ERROR_MENU_BUTTON);
                menuButton.Click();
                Thread.Sleep(2000);
                b = _errorPage.isPageLoadedProperly();
            }

            if (b)
            {
                _test.Log(Status.Pass, str + " page was loaded properly.");
                return true;
            }
            _test.Log(Status.Pass, str + " page wasn't loaded properly.");
            return false;


        }

        public IWebElement findElement(By by)
        {
            IWebElement webElement;
            try
            {
                webElement = _driver.FindElement(by);
                _test.Info("IWebElement " + by.ToString() + " was found.");
            }
            catch (Exception ex)
            {
                webElement = null;
                _test.Info("Couldn't find IWebElement: " + by.ToString());
            }
            return webElement;
        }

        public Boolean areElementsPresent(params By[] bys)
        {
            foreach (By by in bys)
            {
                IWebElement webElement = this.findElement(by);
                //webElement == null ? return true  : false;
                if (webElement == null)
                {
                    _test.Log(Status.Fail, "Some elements were not found.");
                    return false;
                }
            }
            _test.Log(Status.Pass, "Every elements were found.");
            return true;
        }

        public bool clickOnButton(string nameOfButton)
        {
            IWebElement webElement;
            if (nameOfButton.Equals("UI Testing"))
            {
                webElement = this.findElement(uiTestingSiteButton);
                if (webElement == null)
                {
                    _test.Log(Status.Fail, "Button called " + nameOfButton + " was not found.");
                    return false;
                }
            }
            else if (nameOfButton.Equals("Home"))
            {
                webElement = this.findElement(HomePage.HOME_MENU_BUTTON);
                if (webElement == null)
                {
                    _test.Log(Status.Fail, "Button called " + nameOfButton + " was not found.");
                    return false;
                }
            }
            else if (nameOfButton.Equals("Go!"))
            {
                webElement = this.findElement(FormPage.SUBMIT_BUTTON);
                if (webElement == null)
                {
                    _test.Log(Status.Fail, "Button called " + nameOfButton + " was not found.");
                    return false;
                }
            }
            else
            {
                _test.Log(Status.Fail, "Couldn't find matching for button called " + nameOfButton + ".");
                return false;
            }
            webElement.Click();
            _test.Log(Status.Pass, "Button called " + nameOfButton + " was found and clicked.");
            return true;
        }

        public bool searchForTagAndText(string p0, string p1)
        {
            Thread.Sleep(1000);
            IWebElement webElement;
            if (p0.Equals("h1") && p1.Equals("Welcome to the Docler Holding QA Department"))
            {
                webElement = this.findElement(HomePage.WELCOME_HEADER);
                if (webElement == null)
                {
                    _test.Log(Status.Fail, "Tag called " + p0 + " was not found.");
                    return false;
                }
            }
            else if (p0.Equals("p") && p1.Equals("This site is dedicated to perform some exercises and demonstrate automated web testing."))
            {
                webElement = this.findElement(HomePage.DESCRIPTION);
                if (webElement == null)
                {
                    _test.Log(Status.Fail, "Tag called " + p0 + " was not found.");
                    return false;
                }
            }
            else
            {
                _test.Log(Status.Fail, "Couldn't find matching for tag and text called " + p0 + " and " + p1 + ".");
                return false;
            }
            if (webElement.Text.Equals(p1))
            {
                //_test.Log(Status.Pass, "Tag and text called " + p0.ToString() + " and " + p1 + " was found and clicked.");
                _test.Log(Status.Pass, "Tag and text called " + p0 + " and " + p1 + " was found.");
                return true;
            }
            else
            {
                _test.Log(Status.Fail, "Tag called " + p0 + " was found, but the text was not as the expected:" + "\n" + p0 + "\n" + p1);
                return false;
            }
        }

    }
}

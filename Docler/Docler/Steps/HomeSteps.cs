using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowParallelTest.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowParallelTest.Steps
{
    [Binding]
    public class HomeSteps
    {
        private IWebDriver _driver;
        private ExtentReports _extent;
        private ExtentTest _test;
        private ScenarioContext _scenarioContext;

        private CommonPage _commonPage;
        private HomePage _homePage;

        public HomeSteps(IWebDriver driver, ExtentTest test, ScenarioContext scenarioContext)
        {
            _driver = driver;
            //_extent = ExtentManager.Instance;
            _test = test;
            _scenarioContext = scenarioContext;

            _commonPage = new CommonPage(_driver, _test);
            _homePage = new HomePage(_driver, _test, _commonPage);
        }

        [Then(@"the Home button has to turn into active status")]
        public void ThenTheHomeButtonHasToTurnIntoActiveStatus()
        {
            Assert.IsTrue(_homePage.isPageLoadedProperly());
            
        }

        [Then(@"I should see in a (.*) tag containing ""(.*)"" text")]
        public void ThenIShouldSeeInATagContainingText(string p0, string p1)
        {
            Assert.IsTrue(_commonPage.searchForTagAndText(p0, p1));
        }






        //[Given(@"I have entered to the home page ""(.*)""")]
        //public void GivenIHaveEnteredToTheHomePage(string pageUrl)
        //{
        //    _driver.Navigate().GoToUrl(pageUrl);
        //    _test.Log(Status.Info, "I navigated to " + pageUrl);
        //    IWebElement title;
        //    try
        //    {
        //        title = _driver.FindElement(By.XPath("//*/title"));
        //    }
        //    catch (Exception e)
        //    {
        //        title = null;
        //    }
        //    if (title != null)
        //    {
        //        String strTitle = title.GetAttribute("innerText");
        //    }

        //    IWebElement logo;
        //    try
        //    {
        //        logo = _driver.FindElement(By.CssSelector(".img-responsive"));
        //        //logo = _driver.FindElement(By.CssSelector("img.dh_logo"));
        //    }
        //    catch (Exception e) { logo = null; }
        //    if (logo != null)
        //    {
        //        String strLogo = logo.GetAttribute("currentSrc");
        //    }
        //    else
        //    {

        //    }

        //    IWebElement homeButton;
        //    homeButton = _driver.FindElement(By.CssSelector("li > a#home"));
        //    String homeButtonClass;
        //    homeButtonClass = homeButton.GetAttribute("parentNode"); //has to be li.active
        //    homeButtonClass = homeButton.GetAttribute("parentElement"); //has to be li.active
        //    Boolean isHomeButtonActive = false;
        //    if (homeButton.Equals("li.active"))
        //    {
        //        isHomeButtonActive = true;
        //    }
        //    else
        //    {
        //        isHomeButtonActive = false;
        //    }
        //    IWebElement homePageH1 = _driver.FindElement(By.CssSelector("div.ui-test > h1"));
        //    IWebElement homePageP = _driver.FindElement(By.CssSelector("p.lead"));


        //    IWebElement formButton;
        //    formButton = _driver.FindElement(By.CssSelector("li > a#form"));
        //    //Both of the has to be visible. How to check visiblility in this? seleniumUtils.findVisibleElement(By..);
        //    IWebElement inputBox = _driver.FindElement(By.CssSelector("input#hello-input"));
        //    IWebElement submitButton = _driver.FindElement(By.CssSelector("span.input-group-btn"));


        //    IWebElement errorButton;
        //    errorButton = _driver.FindElement(By.CssSelector("li > a#error"));
        //    IWebElement errorResponse;
        //    errorResponse = _driver.FindElement(By.CssSelector("h1"));
        //    String errorResponseStr = errorResponse.Text;
        //    String expectedErrorResponse = "<h1>404 Error: File not found :-(</h1>";
        //    //http://uitest.duodecadits.com/error ezt kapja a network alatt

        //    IWebElement uiTestingSiteButton;
        //    uiTestingSiteButton = _driver.FindElement(By.CssSelector("a.navbar-brand"));





        //    //Thread.Sleep(2000);
        //}

        //[Given(@"On the Form page, if you type (.*) the input field and submit the form, you should get redirect to the Hello page, and the following text should appear: (.*)")]
        //public void GivenOnTheFormPageIfYouTypeTheInputFieldAndSubmitTheFormYouShouldGetRedirectToTheHelloPageAndTheFollowingTextShouldAppear(string p0, string p1, Table table)
        //{
        //    ScenarioContext.Current.Pending();
        //}


    }
}

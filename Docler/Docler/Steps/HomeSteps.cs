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
        private ExtentTest _test;
        private ScenarioContext _scenarioContext;
        private CommonPage _commonPage;
        private HomePage _homePage;

        public HomeSteps(IWebDriver driver, ExtentTest test, ScenarioContext scenarioContext)
        {
            _driver = driver;
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

    }
}

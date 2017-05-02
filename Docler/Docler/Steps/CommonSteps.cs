using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowParallelTest.Pages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowParallelTest.Steps
{
    [Binding]
    public class CommonSteps
    {
        private IWebDriver _driver;
        private ExtentReports _extent;
        private ExtentTest _test;
        private ScenarioContext _scenarioContext;
        
        private CommonPage _commonPage;
        private HomePage _homePage;
        private FormPage _formPage;
        private ErrorPage _errorPage;
        private String _currentPage;

        public CommonSteps(IWebDriver driver, ExtentTest test, ScenarioContext scenarioContext)
        {
            _driver = driver;
            //_extent = ExtentManager.Instance;
            _test = test;
            _scenarioContext = scenarioContext;
            _commonPage = new CommonPage(_driver, _test);
            _homePage = new HomePage(_driver, _test, _commonPage);
            _formPage = new FormPage(_driver, _test, _commonPage);
        }

        [Given(@"I have entered to the home page ""(.*)""")]
        public void GivenIHaveEnteredToTheHomePage(string pageUrl)
        {
            //Assert.True(/*navigate to the home page and check if its loaded and return true or false*/);
            //vagy át kell adni a _test-t és abba beállítani v Assert.assertTrue() ? _test.Pass : _test.Fail
            Assert.IsTrue(_commonPage.navigateTo(pageUrl));
            //Assert.IsFalse(commonPage.navigateTo(pageUrl));
        }

        //[When(@"I navigate to the <pages> page")]
        //public void WhenINavigateToThePage(IList<dynamic> pages)
        //{
        //    foreach (var page in pages)
        //    {
        //        Assert.IsTrue(_commonPage.navigateToPage(page.pages));
        //    }

        //}

        [When(@"I navigate to the (.*) page")]
        public void WhenINavigateToThePage(String page)
        {
            _currentPage = page;
            Assert.IsTrue(_commonPage.navigateToPage(page));
        }

        [Then(@"I should see the title ""(.*)""")]
        public void ThenIShouldSeeTheTitle(string p0)
        {
            if (!_currentPage.Equals("Error"))
            {
                Assert.IsTrue(_commonPage.areElementsPresent(CommonPage.TITLE));
            }
        }

        [Then(@"I should see the Logo")]
        public void ThenIShouldSeeTheLogo()
        {
            if (!_currentPage.Equals("Error"))
            {
                Assert.IsTrue(_commonPage.areElementsPresent(CommonPage.LOGO));
            }
        }

        [When(@"I click on the ""(.*)"" button")]
        public void WhenIClickOnTheButton(string nameOfButton)
        {
            Assert.IsTrue(_commonPage.clickOnButton(nameOfButton));
        }

        [Then(@"I should be navigated to the Home page")]
        public void ThenIShouldBeNavigatedToTheHomePage()
        {
            Assert.IsTrue(_homePage.isPageLoadedProperly());
        }

        [Then(@"I should be navigated to the Form page")]
        public void ThenIShouldBeNavigatedToTheFormPage()
        {
            Assert.IsTrue(_formPage.isPageLoadedProperly());
        }


    }
}

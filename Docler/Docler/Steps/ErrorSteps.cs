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
    public class ErrorSteps
    {
        private IWebDriver _driver;
        private ExtentReports _extent;
        private ExtentTest _test;
        private ScenarioContext _scenarioContext;

        private CommonPage _commonPage;
        private ErrorPage _errorPage;

        public ErrorSteps(IWebDriver driver, ExtentTest test, ScenarioContext scenarioContext)
        {
            _driver = driver;
            //_extent = ExtentManager.Instance;
            _test = test;
            _scenarioContext = scenarioContext;

            _commonPage = new CommonPage(_driver, _test);
            _errorPage = new ErrorPage(_driver, _test, _commonPage);
        }

        [Then(@"I should get a (.*) HTTP response code")]
        public void ThenIShouldGetAHTTPResponseCode(int p0)
        {
            Assert.IsTrue(_errorPage.checkHTTPResponse(p0));
        }


    }
}

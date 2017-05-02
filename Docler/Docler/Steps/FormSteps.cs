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
    public class FormSteps
    {
        private IWebDriver _driver;
        private ExtentTest _test;
        private ScenarioContext _scenarioContext;
        private CommonPage _commonPage;
        private FormPage _formPage;

        public FormSteps(IWebDriver driver, ExtentTest test, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _test = test;
            _scenarioContext = scenarioContext;
            _commonPage = new CommonPage(_driver, _test);
            _formPage = new FormPage(_driver, _test, _commonPage);
        }

        [When(@"I type (.*) into the input box")]
        public void WhenITypeIntoTheInputBox(string p0)
        {
            Assert.IsTrue(_formPage.writeTextIntoElement(p0));
        }

        [When(@"I click on submit button")]
        public void WhenIClickOnSubmitButton()
        {
            Assert.IsTrue(_commonPage.clickOnButton("Go!"));
        }

        [Then(@"I should be redirected to the Hello page")]
        public void ThenIShouldBeRedirectedToTheHelloPage()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(_driver.Url.Contains("http://uitest.duodecadits.com/hello"));
        }

        [Then(@"I should see the (.*) text on it")]
        public void ThenIShouldSeeTheHelloJohnTextOnIt(String helloText)
        {
            Assert.IsTrue(_formPage.checkHelloText(helloText));
        }

        [Then(@"I should see one input box")]
        public void ThenIShouldSeeOneInputBox()
        {
            Assert.IsTrue(_commonPage.findElement(FormPage.INPUT_BOX) != null ? true : false);
        }

        [Then(@"I should see one submit button")]
        public void ThenIShouldSeeOneSubmitButton()
        {
            Assert.IsTrue(_commonPage.findElement(FormPage.SUBMIT_BUTTON) != null ? true : false);
        }

    }
}

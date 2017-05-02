using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowParallelTest.Steps
{
    [Binding]
    public class LoginSteps
    {

        private IWebDriver _driver;
        private ExtentReports _extent;
        private ExtentTest _test;
        private ScenarioContext _scenarioContext;

        public LoginSteps(IWebDriver driver, ExtentTest test, ScenarioContext scenarioContext)
        {
            _driver = driver;
            //_extent = ExtentManager.Instance;
            _test = test;
            _scenarioContext = scenarioContext;

        }


        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            _driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            _test.Log(Status.Info, "I navigated to http://executeautomation.com/demosite/Login.html");
            //_test.Log(Status.Pass, ScenarioContext.Current.StepContext.StepInfo.Text);
            _test.Log(Status.Pass, _scenarioContext.StepContext.StepInfo.Text);
        }

        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            //_driver.FindElement(By.Name("UserName")).SendKeys((String)data.UserName);
            var element = _driver.FindElement(By.XPath("//*[@name='UserName']"));
            string str = data.UserName;
            element.SendKeys(str);

            _driver.FindElement(By.Name("Password")).SendKeys((String)data.Password);
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            Thread.Sleep(5000);
            _driver.FindElement(By.Name("Login")).Submit();
            Thread.Sleep(2000);
        }

        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            var element = _driver.FindElement(By.XPath("//h1[contains(text(),'Execute Automation Selenium')]"));

            //An way to assert multiple properties of single test
            Assert.Multiple(() =>
            {
                //Assert.That(element.Text, Is.Null, "Header text not found !!!");
                Assert.That(element.Text, Is.Not.Null, "Header text not found !!!");
            });
        }

        [Given(@"I navigate to Google\.com")]
        public void GivenINavigateToGoogle_Com()
        {
            _driver.Navigate().GoToUrl("https://google.com");
            //Assert.True(_driver.FindElement(By.CssSelector("asdasda")).Displayed);
            //_test.Fail("Couldn't find logo.");
            //_test.Log(Status.Fail, "fail");
            //_test.Fail(Status.Fail.ToString());
            _test.Log(Status.Info, "I navigated to https://google.com");
            Assert.True(isLogoDisplayed());

            //Thread.Sleep(500);
        }

        public Boolean isLogoDisplayed()
        {
            IWebElement logo;
            try
            {
                logo = _driver.FindElement(By.CssSelector("asdasda"));
            }
            catch (Exception e)
            {
                logo = null;
            }

            if (logo != null)
            {
                _test.Pass("Logo was found.");
                return true;
            }
            else
            {
                _test.Log(Status.Fail, "Failed");
                _test.Fail("Couldn't find logo.");
                return false;
            }

        }



    }
}

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowParallelTest
{
    [Binding]
    public class Hooks
    {

        private readonly IObjectContainer _objectContainer;

        private IWebDriver _driver;

        private ExtentReports _extent;

        private ExtentTest _test;

        //private ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _extent = ExtentManager.Instance;
        }

        [BeforeTestRun]
        protected static void Setup()
        {
            //var dir = "C:\\Users\\vp05\\Documents\\Visual Studio 2015\\Projects\\SpecflowSeleniumParallel-master\\SpecflowParallelTest\\bin\\Debug\\";
            //var fileName = "SpecflowParallelTest.html";
            //var htmlReporter = new ExtentHtmlReporter(dir + fileName);
            //extent = new ExtentReports();
            //extent.AttachReporter(htmlReporter);
        }

        

        [BeforeScenario]
        public void Initialize()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name, "Sample description");
            _test.Log(Status.Info, "BeforeScenario");

            var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembl‌​y().Location);
            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
            //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            //service.HideCommandPromptWindow = true;
            //service.SuppressInitialDiagnosticInformation = true;
            //_driver = new FirefoxDriver(service);

            ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService(driverDir, "chromedriver.exe");
            _driver = new ChromeDriver(chromeService);
            Thread.Sleep(1000);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            _objectContainer.RegisterInstanceAs<ExtentTest>(_test);
        }

        [AfterScenario]
        public void CleanUp()
        {
            _extent.Flush();
            
            Thread.Sleep(2000);
            _driver.Quit();
            //_driver.Close();
            Thread.Sleep(1000);
        }

        [AfterTestRun]
        protected static void TearDown()
        {
            //ExtentManager.Instance.Flush();
        }    

    }
}

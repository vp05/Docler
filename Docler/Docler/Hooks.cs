using AventStack.ExtentReports;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.Threading;
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

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _extent = ExtentManager.Instance;
        }

        [BeforeTestRun]
        protected static void Setup() { }

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
            Thread.Sleep(1000);
        }

        [AfterTestRun]
        protected static void TearDown() { }

    }
}

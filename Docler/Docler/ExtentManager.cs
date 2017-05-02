using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace SpecflowParallelTest
{
    class ExtentManager
    {

        private static readonly ExtentReports _instance = new ExtentReports();

        static ExtentManager()
        {
            DateTime dateTime = DateTime.Now;
            String dateTimeStr = dateTime.Year + "" + (dateTime.Month < 10 ? ("0" + dateTime.Month) : ("" + dateTime.Month)) + "" + (dateTime.Day < 10 ? ("0" + dateTime.Day) : ("" + dateTime.Day)) + "-" + dateTime.Hour + dateTime.Minute + dateTime.Second + "." + dateTime.Millisecond;
            String asd = AppDomain.CurrentDomain.BaseDirectory;
            //var htmlReporter = new ExtentHtmlReporter("C:\\Users\\vp05\\Documents\\Visual Studio 2015\\Projects\\SpecflowSeleniumParallel-master\\SpecflowParallelTest\\bin\\Debug\\Extent.html");
            //var htmlReporter = new ExtentHtmlReporter("Extent_" + dateTime.ToString() + ".html");
            var htmlReporter = new ExtentHtmlReporter("C:\\Users\\vp05\\Work\\Docler\\Docler\\Docler\\bin\\Debug\\" + "Extent " + dateTimeStr + ".html");

            Instance.AttachReporter(htmlReporter);
        }

        private ExtentManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}

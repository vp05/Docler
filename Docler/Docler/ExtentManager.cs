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
            String path = AppDomain.CurrentDomain.BaseDirectory;
            var htmlReporter = new ExtentHtmlReporter(path + "Extent " + dateTimeStr + ".html");
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

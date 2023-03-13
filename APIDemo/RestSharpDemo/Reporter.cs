using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace RestSharpDemo
{
    public static class Reporter
    {
        private static ExtentReports extentReports;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest extentTest;

        public static void SetUpReport(dynamic path, string documentTitle, string reportName)
        {
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = documentTitle;
            htmlReporter.Config.ReportName = reportName;

            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }
        public static void LogToReport(Status status, string message)
        {
            extentTest.Log(status, message);
        }

        public static void CreateTest(string testName)
        {
            extentTest = extentReports.CreateTest(testName);
        }
        public static void FlusReport()
        {
            extentReports.Flush();
        }
        public static void TestStatus(string status)
        {
            if(status.Equals("Pass"))
            {
                extentTest.Pass("Test case passed");
            }
            else
            {
                extentTest.Fail("Test case failed");
            }
        }
    }
}

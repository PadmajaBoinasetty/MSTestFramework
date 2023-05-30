using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using AventStack.ExtentReports.Model;

namespace CSharpFrameWork
{
    public class Reports:BaseTest
    {
        public ExtentTest Test;
        IWebDriver driver;
        public TestContext TestContext { get; set; }

        [TestCleanup]
        public void AfterMethod()
        {
            var exec_status = TestContext.CurrentTestOutcome;
            Status logstatus;//= Status.Pass;
            String screenShotPath, fileName;
            fileName = "Screenshot_" + DateTime.Now.ToString("h_mm_ss") + TestContext.TestName + ".png";

            switch (exec_status)
            {
                case UnitTestOutcome.Failed:
                    logstatus = Status.Fail;
                    screenShotPath = Capture(driver, fileName);
                    var mediaEntity = CaptureScreenShot(driver, fileName);
                    Test.Fail("ExtentReport 4 Capture: Test Failed", mediaEntity).AddScreenCaptureFromPath(screenShotPath);
                    break;
                case UnitTestOutcome.Passed:
                    logstatus = Status.Pass;
                    //screenShotPath = Capture(Driver, fileName);
                    //Test.Log(Status.Pass, "Pass");
                    if (Test != null)
                    {
                        Test.Log(Status.Pass, "Pass");
                    }
                    else
                    {
                        Console.WriteLine("Test is null here");
                        // Handle the case when the Test object is null
                    }
                    break;
                default:
                    break;
            }

        }

        public string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            var reportPath = AppDomain.CurrentDomain.BaseDirectory + "Reports\\" + "Screenshots";

            if (!Directory.Exists(reportPath))
                Directory.CreateDirectory(reportPath);

            var finalpth = reportPath + "\\" + screenShotName;

            screenshot.SaveAsFile(finalpth, ScreenshotImageFormat.Png);

            return reportPath;
        }
        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }

    }
    public class ExtentManager
    {
        private static readonly ExtentReports _instance = new ExtentReports();

        static ExtentManager()
        {
            var reportPath = AppDomain.CurrentDomain.BaseDirectory + @"test-output\";
            var htmlReporter = new ExtentLoggerReporter(reportPath);

            htmlReporter.Config.EnableTimeline = true;
            htmlReporter.Config.DocumentTitle = "Automation Test";
            htmlReporter.Config.Encoding = "utf-8";
            htmlReporter.Config.ReportName = "Test Dashboard";
            htmlReporter.Config.Theme = Theme.Dark;

            Instance.AddSystemInfo("Tester Name", "Padmaja");
            Instance.AttachReporter(htmlReporter);

        }
        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}

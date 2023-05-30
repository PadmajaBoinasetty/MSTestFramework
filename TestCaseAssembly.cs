using AventStack.ExtentReports;
using CSharpFrameWork.Logs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CSharpFrameWork
{
    [TestClass]
    public class TestCaseAssembly
    {
        public static ExtentReports Extent;

        [AssemblyInitialize]
        public static void OneTimeSetup(TestContext testContext)
        {
            Extent = ExtentManager.Instance;
            LogConfig.LoadLog4NetConfig();
        }

        [AssemblyCleanup]
        public static void EndReport()
        {
            Extent.Flush();
        }
    }
}

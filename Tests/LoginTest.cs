using CSharpFrameWork.Pages;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFrameWork.Tests
{
    [TestClass]
    public class LoginTest:Reports
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(LoginTest));
        public LoginPage loginpage;

        /*Marks a method that should be called before each test method. One such method should be present per test class.
         */
        [TestInitialize]
        public void Initialize()
        {
            loginpage = new LoginPage(driver);
        }

        /*Marks a method,that is an actual test case in the test class.
         */
        [TestMethod]
        public void VerifyLogin()
        {
            Test = TestCaseAssembly.Extent.CreateTest(TestContext.TestName);
            loginpage.Login("saijyothi123456", "Saijyothi@123");
            Assert.Fail();
        }

    }
}

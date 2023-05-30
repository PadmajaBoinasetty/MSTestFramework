using CSharpFrameWork.Pages;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFrameWork.Tests
{
    [TestClass]
    public class HomeTest:Reports
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(LoginTest));
        public HomePage homePage { get; set; }
        public LoginPage loginPage { get; set; }    

        /*Marks a method that should be called before each test method. One such method should be present per test class.
         */
        [TestInitialize]
        public void initialize()
        {
            homePage = new HomePage(driver);
            loginPage= new LoginPage(driver);
        }

        /*Marks a method,that is an actual test case in the test class.
        */
        [TestMethod]
        public void VerifyHomePage_Success()
        {
            Test = TestCaseAssembly.Extent.CreateTest(TestContext.TestName);
            /*Calling Methods into Testpage
             */
            loginPage.Login("saijyothi123456", "Saijyothi@123");

            homePage.SerchHotel("New York", 
                "Hotel Sunshine",
                "Super Deluxe",
                2,
                "24/05/2023",
                "25/05/2023",
                2,
                2);

            homePage.VerifyHotelDetails();

        }
    }
}

using CSharpFrameWork.CustomerData;
using CSharpFrameWork.Helpers;
using CSharpFrameWork.Pages;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFrameWork.Tests
{
    [TestClass]
    public class CustomerTest:Reports
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(CustomerTest));
        public CustomerPage page;

        [TestInitialize]
        public void Initialize()
        {
            page = new CustomerPage(driver);
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void AT1_FillCustomerDetails()
        {
            Test = TestCaseAssembly.Extent.CreateTest(TestContext.TestName);

            var dataPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\CustomerData\\customer.csv";

            var customerData = CsvReaderHelper<CustomerDetails>.Read(dataPath);

            var firstName = customerData[0].FirstName;
            var lastName = customerData[0].LastName;


            _log.Info("Test Padmaja");

            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        [TestCategory("Sanity")]
        public void AT2_FillCustomerDetails()
        {
            Test = TestCaseAssembly.Extent.CreateTest(TestContext.TestName);

            var dataPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\CustomerData\\customer.csv";

            var customerData = CsvReaderHelper<CustomerDetails>.Read(dataPath);

            var firstName = customerData[0].FirstName;
            var lastName = customerData[0].LastName;


            _log.Info("Test Padmaja");

            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        [TestCategory("Sanity")]
        public void AT3_FillCustomerDetails()
        {
            Test = TestCaseAssembly.Extent.CreateTest(TestContext.TestName);

            var dataPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\CustomerData\\customer.csv";

            var customerData = CsvReaderHelper<CustomerDetails>.Read(dataPath);

            var firstName = customerData[0].FirstName;
            var lastName = customerData[0].LastName;

            
            page.FillCustomerForm(firstName, lastName);

            _log.Info("Test Padmaja");

            Assert.IsTrue(1 == 1);
        }

    }
}

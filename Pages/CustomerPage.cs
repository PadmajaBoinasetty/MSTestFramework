using CSharpFrameWork.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpFrameWork.Pages
{
    public class CustomerPage
    {
        Actions actions = new Actions();
        IWebDriver driver;

        public CustomerPage(IWebDriver driver)
        {
            this.driver= driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='FirstName']")]
        private readonly IWebElement FirstName;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='LastName']")]
        private readonly IWebElement LastName;

        public void FillCustomerForm(string data1, string data2)
        {
            actions.TypeValue(FirstName, data1);
            actions.TypeValue(LastName, data2);
        }
    }
}

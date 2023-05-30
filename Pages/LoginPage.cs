using CSharpFrameWork.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpFrameWork.Pages
{
    public class LoginPage
    {
         IWebDriver driver;

        /*Creating object for CommonMethods
         */

        Actions actions = new Actions();

        /*Creating Constructor to assign driver for this page
         */
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "username")]
        IWebElement UserNameInputBox;

        [FindsBy(How = How.Id, Using = "password")]
        IWebElement PasswordInputBox;

        [FindsBy(How = How.CssSelector, Using = "[class='login_button']")]
        IWebElement LoginButton;


        public void Login(string UserName, string Password)
        {

            actions.TypeValue(UserNameInputBox, UserName);

            actions.TypeValue(PasswordInputBox, Password);

            actions.ClickOnElement(LoginButton);

            /*Created string to verify the page title 
             */

            //string actualMessage = driver.FindElement(By.XPath("//td[text()='Welcome to Adactin Group of Hotels']")).Text;

            //string message = driver.FindElement(By.XPath("//td[@class='welcome_menu'][1]")).Text;


            /*Using assertAreEqual to check the title is equal or not
             */


            //Assert.AreEqual(message, actualMessage, "Assert Failed");

            /*Using printing statment to print the assertion.
             */

            //Console.WriteLine(actualMessage);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);



        }
    }
}

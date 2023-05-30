using CSharpFrameWork.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpFrameWork.Pages
{
    public class HomePage
    {
        IWebDriver driver;

        /*Creating object for CommonMethods
         */

        Actions actions = new Actions();

        /*Creating Constructor to assign driver for this page
         */
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "[id='location']")]
        IWebElement Location;

        [FindsBy(How = How.Id, Using = ("hotels"))]
        IWebElement HotelType;

        [FindsBy(How = How.CssSelector, Using = "[id='room_type']")]
        IWebElement RoomType;

        [FindsBy(How = How.Id, Using = ("room_nos"))]
        IWebElement NumberofRooms;

        [FindsBy(How = How.XPath, Using = "//input[@id=\"datepick_in\"]")]
        IWebElement Checkindate;

        [FindsBy(How = How.XPath, Using = "//input[@id=\"datepick_out\"]")]
        IWebElement Checkoutdate;

        [FindsBy(How = How.CssSelector, Using = "[id='adult_room']")]
        IWebElement Adultcount;

        [FindsBy(How = How.CssSelector, Using = "[id='child_room']")]
        IWebElement Childerncount;


        [FindsBy(How = How.Name, Using = "Submit")]
        IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//input[@name='radiobutton_0']")]
        IWebElement RadioButton;

        [FindsBy(How = How.CssSelector, Using = "[id='continue']")]
        IWebElement ContinueButton;
        public void SerchHotel(string loc,string hotel, string room, int no_of_rooms,string inDate, string outdate, int noOfAdults, int noOfChildren)
        {
            actions.SelectByText(Location, loc);
            actions.SelectByText(HotelType, hotel);
            actions.SelectByText(RoomType, room);
            actions.SelectByIndex(NumberofRooms, no_of_rooms);
            actions.TypeValue(Checkindate, inDate);
            actions.TypeValue(Checkoutdate, outdate);
            actions.SelectByIndex(Adultcount, noOfAdults);
            actions.SelectByIndex(Childerncount, noOfChildren);
            actions.ClickOnElement(SearchButton);
        }
        public void VerifyHotelDetails()
        {
            actions.ClickOnElement(RadioButton);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("oldChrome.png");
            WebDriverWait wt = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            actions.ClickOnElement(ContinueButton);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
    }
}

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace CSharpFrameWork.Helpers
{
    public class Actions
    {
        public IWebDriver driver;
        public void ClickOnElement(IWebElement element)
        {
            element.Click();
        }

        public void ClearField(IWebElement webElement)
        {
            webElement.Clear();
        }

        public void TypeValue(IWebElement webElement, string fieldValue)
        {
            webElement.SendKeys(fieldValue);
        }

        public string GetText(IWebElement webElement)
        {
            return webElement.Text;
        }

        public bool IsEnabled(IWebElement webElement)
        {
            return webElement.Enabled;
        }

        public bool IsSelected(IWebElement webElement)
        {
            return webElement.Selected;
        }

        public List<string> GetWindowHandles()
        {
            return driver.WindowHandles.ToList();
        }

        public IWebDriver SwitchWindows(string windowId)
        {
            return driver.SwitchTo().Window(windowId);
        }

        public IWebDriver SwitchFrames(IWebElement framePath)
        {
            return driver.SwitchTo().Frame(framePath);
        }

        public string GetPageTitle(IWebDriver driver)
        {
            return driver.Title;
        }

        public void SelectByValue(IWebElement webElement, string valueToBeSelected)
        {
            var selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(valueToBeSelected);
        }

        public void SelectByText(IWebElement webElement, string valueToBeSelected)
        {
            var selectElement = new SelectElement(webElement);
            selectElement.SelectByText(valueToBeSelected);
        }
        public void SelectByIndex(IWebElement webElement, int indexToBeSelected)
        {
            var selectElement = new SelectElement(webElement);
            selectElement.SelectByIndex(indexToBeSelected);
        }
    }
}

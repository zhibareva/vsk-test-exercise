using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace NUnitTestProject1
{
    class NavigationHelper
    {
        private WebDriver driver;
        private WebDriverWait wait;

        public NavigationHelper(WebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void clickOnElement(By element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            driver.FindElement(element).Click();
        }

        public By getDynamicLocator(string locator, string value) {
            return By.XPath(string.Format(locator, value));
        }

        public void fillInput(By locator, string inputValue)
        {
            clickOnElement(locator);
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(inputValue);
        }
    }
}

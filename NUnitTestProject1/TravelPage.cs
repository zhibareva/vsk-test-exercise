using NUnitTestProject1;
using OpenQA.Selenium;

namespace VskAutoTest
{
    class TravelPage
    {
        private NavigationHelper navigationHelper;

        public TravelPage(WebDriver driver)
        {
            navigationHelper = new NavigationHelper(driver);
        }

        public By travelTab = By.XPath("//div[@itemscope='itemscope']//a[@routerlink='/travel']");
        public By calcPolicyButton = By.Id("travel_banner_button_buy");
        public By cityCountryDropdown = By.XPath("//div[@automation-id='tui-multi-select__arrow']");
        public string cityCountryDropdownElement ="//button[contains(., '{0}')]";
        public string dateCalendar = "//label[@label='{0}']//span[@class='content']//tui-input-date//tui-hosted-dropdown//div//tui-primitive-textfield//tui-wrapper//input";
        public By nextStepButton = By.XPath("//button[@id='sidebar_step_next']");

        public void selectCityCountry(string location) 
        {
            navigationHelper.clickOnElement(cityCountryDropdown);
            By element = navigationHelper.getDynamicLocator(cityCountryDropdownElement, location);
            navigationHelper.clickOnElement(element);
            navigationHelper.clickOnElement(cityCountryDropdown);
        }

        public void selectDate(string dateType, string date)
        {
            By element = navigationHelper.getDynamicLocator(dateCalendar, dateType);
            navigationHelper.fillInput(element, date);
            
        }
    }
}

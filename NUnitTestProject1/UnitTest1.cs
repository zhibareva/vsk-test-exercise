using NUnit.Framework;
using NUnitTestProject1;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace VskAutoTest
{
    public class Tests
    {
        private WebDriver webDriver;
        private NavigationHelper navigationHelper;

        [SetUp]
        public void SetupTest()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(Constants.BaseUrl);
            navigationHelper = new NavigationHelper(webDriver);
        }

        [TearDown]
        public void TeardownTest()
        {
            webDriver.Quit();
        }

        [Test]
        [TestCase(5, 15, "Египет")]
        public void Test(int rangeDaysStart, int rangeDaysEnd, string location)
        {
            TravelPage travelPage = new TravelPage(webDriver);
            // Перейти на вкладку «Путешествия»
            navigationHelper.clickOnElement(travelPage.travelTab);
            // Нажать кнопку «Купить полис»
            navigationHelper.clickOnElement(travelPage.calcPolicyButton);
            // Заполнить поля
            travelPage.selectCityCountry(location);
            string startDate = DateTime.Now.AddDays(rangeDaysStart).ToString(Constants.DateFormat);
            string endDate = DateTime.Now.AddDays(rangeDaysEnd).ToString(Constants.DateFormat);
            travelPage.selectDate("Дата начала", startDate);
            travelPage.selectDate("Дата окончания", endDate);
            // Нажать кнопку «Оформить полис»
            navigationHelper.clickOnElement(travelPage.nextStepButton);
        }
    }
}
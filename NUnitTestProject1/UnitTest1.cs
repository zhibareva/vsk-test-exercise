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
        [TestCase(5, 15, "������")]
        public void Test(int rangeDaysStart, int rangeDaysEnd, string location)
        {
            TravelPage travelPage = new TravelPage(webDriver);
            // ������� �� ������� �������������
            navigationHelper.clickOnElement(travelPage.travelTab);
            // ������ ������ ������� �����
            navigationHelper.clickOnElement(travelPage.calcPolicyButton);
            // ��������� ����
            travelPage.selectCityCountry(location);
            string startDate = DateTime.Now.AddDays(rangeDaysStart).ToString(Constants.DateFormat);
            string endDate = DateTime.Now.AddDays(rangeDaysEnd).ToString(Constants.DateFormat);
            travelPage.selectDate("���� ������", startDate);
            travelPage.selectDate("���� ���������", endDate);
            // ������ ������ ��������� �����
            navigationHelper.clickOnElement(travelPage.nextStepButton);
        }
    }
}
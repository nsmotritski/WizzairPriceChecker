using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Globalization;

namespace WizzairPriceChecker
{
    class NUnitTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void OpenAppTest()
        {
            driver.Url = "http://www.wizzair.com";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //set Origin Airport
            var UIOriginEdit = driver.FindElement(By.XPath("//input[@placeholder='Origin']"));
            UIOriginEdit.Clear();
            UIOriginEdit.SendKeys("Barcelona El Prat");

            var locationContainerLabelOrigin = driver.FindElement(By.XPath("//label[@data-test='flight-search-panel-location-label']"));
            locationContainerLabelOrigin.Click();

            //set Destination Airport
            var UIDestinationEdit = driver.FindElement(By.XPath("//input[@placeholder='Destination']"));
            UIOriginEdit.Clear();
            UIDestinationEdit.SendKeys("Vilnius");

            var locationContainerLabelDestination = driver.FindElement(By.XPath("//label[@data-test='flight-search-panel-location-label']"));
            locationContainerLabelDestination.Click();

            //set departure date
            var UIDepartureDate = driver.FindElement(By.XPath("//div[@id='search-departure-date']"));
            var departureDateDefaultText = DateTime.Today.AddDays(1).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            var departureActualText = new DateTime(2018, 7, 14).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            UIDepartureDate.Text.Replace(oldValue: departureDateDefaultText, newValue: departureActualText);

            
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }

    }
}

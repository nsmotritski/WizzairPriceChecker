using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizzairPriceChecker
{
    class HomePage
    {
        IWebDriver driver;
        IWebElement UIOriginEdit;
        IWebElement UIDestinationEdit;
        IWebElement UIDepartureDate;
        IWebElement UIPassengersNumber;
        
        public static void SetOriginAirport(IWebDriver driver, string aiportFullName)
        {
            var UIOriginEdit = driver.FindElement(By.XPath("//input[@placeholder='Origin']"));
            UIOriginEdit.Clear();
            UIOriginEdit.SendKeys(aiportFullName);

            var locationContainerLabelOrigin = driver.FindElement(By.XPath("//label[@data-test='flight-search-panel-location-label']"));
            locationContainerLabelOrigin.Click();
        }

        public static void SetDestinationAirport(IWebDriver driver, string aiportFullName)
        {
            var UIDestinationEdit = driver.FindElement(By.XPath("//input[@placeholder='Destination']"));
            UIDestinationEdit.Clear();
            UIDestinationEdit.SendKeys(aiportFullName);

            var locationContainerLabelDestination = driver.FindElement(By.XPath("//label[@data-test='flight-search-panel-location-label']"));
            locationContainerLabelDestination.Click();
        }
    }
}

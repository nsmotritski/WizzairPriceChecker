using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static void SetDepartureDate (IWebDriver driver, DateTime departureDate)
        {
            var UICalendarNextButton = driver.FindElement(By.XPath("//button[@class='pika-next']"));
            var UICalendarOKButton = driver.FindElement(By.XPath("//button[contains(@class,'rf-button--shrinkable')]"));
            var UIDepartureDate = driver.FindElement(By.XPath("//div[@id='search-departure-date']"));
            var departureDateDefaultText = DateTime.Today.AddDays(1).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            var departureActualText = departureDate.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            UIDepartureDate.Click();
            //driver.FindElement(By.XPath("//div[@id='search-departure-date']"), 15);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElement(By.XPath("//button[@class='pika-next']")).Displayed);
            
            //wait.Until(ExpectedConditions.ElementToBeClickable("//button[@class='pika-next']"));
            UICalendarNextButton.Click();
            UIDepartureDate.Text.Replace(oldValue: departureDateDefaultText, newValue: departureActualText);
            UIDepartureDate.SendKeys(Keys.Enter);
        }
    }
}

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
            string departureAirport = "BCN";
            string arrivalAirport = "VNO";
            
            
            DateTime departureDate = new DateTime(2018, 07, 14);
            string departureDateString = departureDate.ToString("yyyy-MM-dd");
            driver.Url = "https://wizzair.com/#/booking/select-flight/" + departureAirport + 
                "/" + arrivalAirport + "/" + departureDateString;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            ////set Origin Airport
            //HomePage.SetOriginAirport(driver, "Barcelona El Prat");

            ////set Destination Airport
            //HomePage.SetDestinationAirport(driver, "Vilnius");

            //set departure date
            HomePage.SetDepartureDate(driver, departureDate);

            //setnumber of passengers
            var UIPassengersNumberEdit = driver.FindElement(By.XPath("//div[@id='search-passenger']"));
            UIPassengersNumberEdit.Click();
        
            var adultNumberIncreaseButton = driver.FindElements(By.XPath("//button[@class='stepper__button stepper__button--add']")).First();
            adultNumberIncreaseButton.Click();

            //click Search button
            var UISubmitButton = driver.FindElement(By.XPath("//button[@data-test='flight-search-submit']"));
            UISubmitButton.Click();

            //wait for page is loaded
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }

    }
}

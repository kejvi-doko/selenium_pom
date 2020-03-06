using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UITesting.Base;

namespace UITesting.Booking.Page
{
    public class SearchHotelPage : BasePage
    {
        public SearchHotelPage(IWebDriver driver) : base(driver)
        {

        }

        private IWebElement destinationDropDown => this.driver.FindElement(By.XPath(@"//div[2]/div/a/span"));
        private IWebElement destinationTextBox => this.driver.FindElement(By.XPath(@"//*[@id=""select2-drop""]/div/input"));
        private IWebElement checkinDateTextBox => this.driver.FindElement(By.Id("checkin"));
        private IWebElement checkoutDateTextBox => this.driver.FindElement(By.Id("checkout"));
        private IWebElement adultsNoTextBox => this.driver.FindElement(By.Name("adults"));
        private IWebElement childrenNoTextBox => this.driver.FindElement(By.Name("children"));
        private IWebElement searchButton => this.driver.FindElement(By.XPath("//div[@id='hotels']/div/div/form/div/div/div[4]/button"));
        private ReadOnlyCollection<IWebElement> destinationListDrowpDown => this.driver.FindElements(By.ClassName("select2-result-sub"));
        
        public void SearchHotel(string destination, DateTime checkinDate, DateTime checkoutDate, int adultsNo, int childNo)
        {
            this.driver.Navigate().GoToUrl("https://www.phptravels.net/home");
            this.driver.Manage().Window.Maximize();

            destinationDropDown.Click();
            destinationTextBox.SendKeys(destination);

            // Wait for results to show up
            WebDriverWait wait = new WebDriverWait(this.driver, new TimeSpan(0, 0, 0, 5));
            wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("select2-result-sub")));

            destinationListDrowpDown.First().Click();
            checkinDateTextBox.Clear();
            checkoutDateTextBox.Clear();
            checkinDateTextBox.SendKeys(checkinDate.ToString("dd/MM/yyyy"));
            checkoutDateTextBox.SendKeys(checkoutDate.ToString("dd/MM/yyyy"));
            adultsNoTextBox.SendKeys($"{adultsNo}");
            childrenNoTextBox.SendKeys($"{childNo}");
            searchButton.Click();

            // Wait for the search to finish
            wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(@"sidebar-title")));
           

        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using UITesting.Base;

namespace UITesting.Authentication.Page
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver):base(driver)
        {

        }
        public IWebElement MyAccountDropdown => this.driver.FindElement(By.ClassName("dropdown-login"));
        public IWebElement LoginButton => this.driver.FindElement(By.XPath(@"/html/body/div[2]/header/div[1]/div/div/div[2]/div/ul/li[3]/div/div/div/a[1]"));
        public IWebElement EmailTextBox => this.driver.FindElement(By.Name("username"));
        public IWebElement PasswordTextBox => this.driver.FindElement(By.Name("password"));
        public IWebElement ConfirmLoginButton => this.driver.FindElement(By.ClassName("loginbtn"));
        public IWebElement GreetingMessage => this.driver.FindElement(By.XPath("//h3"));
        public void Login(string username, string password)
        {
            this.driver.Navigate().GoToUrl("https://www.phptravels.net/home");

            MyAccountDropdown.Click();

            WebDriverWait wait = new WebDriverWait(this.driver, new TimeSpan(0, 0, 0, 5));
            wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/div[2]/header/div[1]/div/div/div[2]/div/ul/li[3]/div/div/div/a[1]")));

            LoginButton.Click();
           
            wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("username")));

            EmailTextBox.SendKeys(username);
            PasswordTextBox.SendKeys(password);
            ConfirmLoginButton.Click();

            wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h3")));
        }

    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace UITesting.Base
{
    public class BaseUnitTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        protected virtual void Setup()
        {
            var baseChromeDrivepath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            this.driver = new ChromeDriver(baseChromeDrivepath);
        }

        [OneTimeTearDown]
        protected virtual void EndTest()
        {
            this.driver.Close();
            this.driver.Quit();
        }

    }
}
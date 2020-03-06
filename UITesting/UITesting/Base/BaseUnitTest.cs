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

            string chromePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            string chromeVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(chromePath).ProductVersion;

            bool driverExists = File.Exists($"{baseChromeDrivepath}\\chromedriver.exe");

            if (driverExists)
            {
                this.driver = new ChromeDriver(baseChromeDrivepath);
            }
            else
            {
                throw new FileNotFoundException($"chromedriver.exe not found in path : {baseChromeDrivepath}. Download the correct version of Chrome Driver ({chromeVersion}) from https://chromedriver.storage.googleapis.com/index.html");
            }
            
        }

        [OneTimeTearDown]
        protected virtual void EndTest()
        {
            this.driver.Close();
            this.driver.Quit();
        }

    }
}
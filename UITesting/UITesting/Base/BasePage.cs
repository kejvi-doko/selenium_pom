using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITesting.Base
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

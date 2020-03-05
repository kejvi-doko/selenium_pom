using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UITesting.Authentication.Page;
using UITesting.Base;

namespace UITesting.Authentication
{
    public class AuthenticationUnitTest: BaseUnitTest
    {
        [Test]
        public void Login()
        {
            LoginPage page = new LoginPage(this.driver);

            page.Login(username: "user@phptravels.com", password: "demouser");
        }

    }
}

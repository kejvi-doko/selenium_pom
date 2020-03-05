using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UITesting.Authentication.Page;
using UITesting.Base;
using UITesting.Booking.Page;

namespace UITesting.Booking
{
    public class BookingUnitTest: BaseUnitTest
    {
        [Test]
        public void SearchForHotel()
        {
            //this.driver.Navigate().GoToUrl("https://www.phptravels.net/home");

            //LoginPage page = new LoginPage(this.driver);

            //page.Login(username: "user@phptravels.com", password: "demouser");

            SearchHotelPage searchPage = new SearchHotelPage(this.driver);

            searchPage.SearchHotel("Tirana", DateTime.Now.AddDays(5), DateTime.Now.AddDays(10), 2, 0);
        }
    }
}

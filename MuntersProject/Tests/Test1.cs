using MuntersProject.Extensions;
using MuntersProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MuntersProject.Tests
{
    public class Test1 : TestBase
    {

        [Test]
        public void Test()
        {
            var username = "demo@munters.co.il";
            var password = "Demo123456";

            Logger.PrintLog("Login to the application");
            var loginPage = new LogInPage(_driver);
            var homePage = loginPage.Login(username, password);
            Logger.PrintLog("Open Swine Demo Menu on Home Page");
            homePage.OpenSwineDemoMenu(1, 0);
            Logger.PrintLog("Open Room Menu");
            homePage.OpenRoomMenu(2, 0);
            Logger.PrintLog("Open Room by index");
            homePage.OpenRoomByIndex(3, 0);
            Logger.PrintLog("Open Controller Menu");
            homePage.OpenControllerMenu();
            Logger.PrintLog("Enter random values in the 1st row");
            homePage.EnterValuesToTable();




        }
    }
}
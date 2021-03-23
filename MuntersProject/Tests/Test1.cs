using MuntersProject.Extensions;
using MuntersProject.Pages;
using NUnit.Framework;
using System;

namespace MuntersProject.Tests
{
    public class Test1 : TestBase
    {

        [Test]
        public void Test()
        {
            try
            {
                var username = "demo@munters.co.il";
                var password = "Demo123456";
                var message = "Changes saved";

                Logger.PrintLog("Login to the application");
                var loginPage = new LogInPage(_driver);
                var homePage = loginPage.Login(username, password);

                Logger.PrintLog("Open Swine Demo Menu on Home Page");
                homePage.OpenSwineDemoMenu(1, 0);

                Logger.PrintLog("Open Room Menu");
                homePage.OpenRoomMenu(2, 0);

                Logger.PrintLog("Open Room by index");
                homePage.OpenRoomByIndex(3, 0);

                Logger.PrintLog("Open Temperature Curve in Controller Menu");
                homePage.OpenControllerMenu();

                Logger.PrintLog("Enter random values in the 1st row");
                homePage.EnterValuesToTable();

                Logger.PrintLog($"Verify message: [{message}] appears after saving changes");
                var isChangesSavedMessage = homePage.VerifySaveChangesMessage(message);

                Assert.IsTrue(isChangesSavedMessage, $"Message after saving changes is not as expected. Expected message: {message}");
            }catch(Exception e)
            {

            }
        }
    }
}
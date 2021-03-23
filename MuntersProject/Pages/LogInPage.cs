using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MuntersProject.Pages
{
    public class LogInPage : PageBase
    {
        public LogInPage(IWebDriver driver) : base("Munters Sign in", driver) { }

        public HomePage Login(string username, string password)
        {
            WaitUntil(ExpectedConditions.ElementToBeClickable(By.Id("signInName")));
            var emailField = FindElement(By.Id("signInName"));
            EnterText(emailField, username);
            var passwordField = FindElement(By.Id("password"));
            EnterText(passwordField, password);
            var signInBtn = FindElement(By.XPath("//button[@id='next']"));
            signInBtn.Click();
            Wait(120);
            return new HomePage(_driver);

        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace MuntersProject.Pages
{
    public class PageBase
    {
        private readonly string _pageTitle;
        public static IWebDriver _driver;
        public Actions _actions;

        public PageBase(string pageTitle, IWebDriver driver = null)
        {
            if (driver != null)
            {
                _driver = driver;
            }
            _pageTitle = pageTitle;
            VerifyPageTitle(_pageTitle);
            _actions = new Actions(_driver);

        }
        public void VerifyPageTitle(string pageTitle)
        {
            try
            {
                WaitUntil(ExpectedConditions.TitleContains(pageTitle), 30);
            }
            catch (Exception ex)
            {
                throw new Exception($"Navigation to page : {pageTitle} failed. Actual page title: {_driver.Title}", ex);
            }
        }

        public void Wait(int timeoutInSeconds = 30)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSeconds);
        }

        public T WaitUntil<T>(Func<IWebDriver, T> condition, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(condition);
        }

        public IWebElement FindElement(By by, int timeoutInSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Until(d => d.FindElement(by));
            }
            catch (TimeoutException)
            {
                return null;
            }
            return _driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by, int timeoutInSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Until(d => (d.FindElements(by)));
            }
            catch (TimeoutException)
            {
                return null;
            }
            return _driver.FindElements(by);
        }

        public void EnterText(IWebElement element, string text)
        {
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

    }
}

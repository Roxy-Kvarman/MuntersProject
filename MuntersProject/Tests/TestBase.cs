using MuntersProject.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuntersProject.Tests
{
    public class TestBase
    {
        public IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArguments("--disable-popup-blocking");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--start-maximized");
            options.AddArgument("Zoom 100%");
            _driver = new ChromeDriver(options);
            _driver.Url = " https://www.trioair.net";
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

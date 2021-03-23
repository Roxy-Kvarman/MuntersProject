using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuntersProject.Pages
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver) : base("RotemCentralApp", driver) { }


        public void OpenSwineDemoMenu(int level, int index)

        {
            var menuOpen = FindElements(By.XPath("//div[@class='e-icons e-icon-collapsible interaction']"));
            if (menuOpen.Any())
            {
                menuOpen.FirstOrDefault().Click();
            }
            OpenTreeItemByLevelAndIndex(level, index);
        }
        public void OpenRoomMenu(int level, int index)
        {
            OpenTreeItemByLevelAndIndex(level, index);
        }
        public void OpenRoomByIndex(int level, int index)
        {
            OpenTreeItemByLevelAndIndex(level, index);
        }
        public void OpenControllerMenu()
        {
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//iframe[contains (@src, 'dashboard')]")));
            WaitUntil(ExpectedConditions.ElementIsVisible(By.CssSelector("button > div.button-icon-24.icon-small.icon-menu")));
            FindElement(By.CssSelector("button.header-item.header-button > div.button-icon-24.icon-small.icon-menu")).Click();
            FindElement(By.XPath("//div[@class='menu-panel']//div[text()=' Temperature Curve ']")).Click();
            WaitUntil(ExpectedConditions.ElementIsVisible(By.XPath("//form//div/span[@class='icon-edit']")));
            FindElement(By.XPath("//form//div/span[@class='icon-edit']")).Click();
            _driver.SwitchTo().DefaultContent();
        }
        public void EnterValuesToTable()
        {

            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//iframe[contains (@src, 'dashboard')]")));
            var row = FindElements(By.XPath("//table[@id='grid_content_table']/tbody/tr"));
            var cells = row.FirstOrDefault().FindElements(By.TagName("td"));
            foreach (var cell in cells)
            {
                var cellField = cell.FindElement(By.TagName("input"));

            }
        }

        private void OpenTreeItemByLevelAndIndex(int level, int index)
        {
            var items = FindElements(By.XPath($"//ul[@class='e-list-parent e-ul ']/li[@aria-level='{level}']"));
            var item = items.ElementAt(index);
            item.Click();
        }

    }
}

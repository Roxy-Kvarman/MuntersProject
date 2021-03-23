using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace MuntersProject.Pages
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver) :
            base("RotemCentralApp", driver)
        {
            WaitUntil(ExpectedConditions.ElementIsVisible(By.TagName("h1")));
        }

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
            WaitUntil(ExpectedConditions.ElementIsVisible(By.XPath("//iframe[contains (@src, 'dashboard')]")));
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//iframe[contains (@src, 'dashboard')]")));
            WaitUntil(ExpectedConditions.ElementToBeClickable(By.CssSelector("button > div.button-icon-24.icon-small.icon-menu")));
            FindElement(By.CssSelector("button.header-item.header-button > div.button-icon-24.icon-small.icon-menu")).Click();
            FindElement(By.XPath("//div[@class='menu-panel']//div[text()=' Temperature Curve ']")).Click();
            WaitUntil(ExpectedConditions.ElementToBeClickable(By.XPath("//form//div/span[@class='icon-edit']")));
            FindElement(By.XPath("//form//div/span[@class='icon-edit']")).Click();
            _driver.SwitchTo().DefaultContent();
        }
        public void EnterValuesToTable()
        {
            double minimum = 0.0, maximum = 0.0;
            string minValue = null, maxValue = null;
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//iframe[contains (@src, 'dashboard')]")));
            var row = FindElements(By.XPath("//table[@id='grid_content_table']/tbody/tr"));
            var cells = row.FirstOrDefault().FindElements(By.XPath("./td[contains(@aria-label, ' is template cell column header c')]"));
            foreach (var cell in cells)
            {
                var cellField = cell.FindElement(By.TagName("input"));
                cellField.Click();
                var rangeInfo = _driver.FindElement(By.XPath("//div[contains(@class,'range-info-box')]/span[@class='range-info']")).Text;
                var values = rangeInfo.Split('–');
                if (values.Length == 2)
                {
                    minValue = values[0].Trim();
                    maxValue = values[1].Trim();
                    double.TryParse(minValue, out minimum);
                    double.TryParse(maxValue, out maximum);
                }
                var randomValue = Helper.Helper.GetRandomNumber(minimum, maximum);
                cellField.SendKeys(Keys.Backspace);
                if (minValue.ToString().Contains('.'))
                {
                    cellField.SendKeys(randomValue.ToString("0.0"));
                }
                else
                {
                    cellField.SendKeys(randomValue.ToString("0"));
                }

            }
            _driver.SwitchTo().DefaultContent();
        }

        public bool VerifySaveChangesMessage(string message)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//iframe[contains (@src, 'dashboard')]")));
            FindElement(By.XPath("//div[contains(@class,'button-save')]")).Click();
            var toastContainer = FindElement(By.Id("toast-container"));
            var text = toastContainer.Text;
            _driver.SwitchTo().DefaultContent();
            return text.Contains(message);
        }

        private void OpenTreeItemByLevelAndIndex(int level, int index)
        {
            WaitUntil(ExpectedConditions.ElementToBeClickable(By.XPath($"//ul[@class='e-list-parent e-ul ']/li[@aria-level='{level}']")));
            var items = FindElements(By.XPath($"//ul[@class='e-list-parent e-ul ']/li[@aria-level='{level}']"));
            var item = items.ElementAt(index);
            item.Click();
        }

    }
}

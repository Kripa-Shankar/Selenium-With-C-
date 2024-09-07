using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotNetSelenium
{
    public class SeleniumCustomMethods
    {
        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public static void SelectDropDownByText(IWebDriver driver, By locator, string text)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByText(text);
        }

        public static void SelectDropDownByValue(IWebDriver driver, By locator, string text)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByValue(text);
        }

        public static void MultipleSelectElements(IWebDriver driver, By locator, string[] values)
        {
            SelectElement multSelect = new SelectElement(driver.FindElement(locator));
            foreach (string value in values)
            {
                multSelect.SelectByValue(value);
            }
        }
        public static List<string> GetAllSelectedList(IWebDriver driver, By locator)
        {
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> selectedOptions = multiSelect.AllSelectedOptions;
            List<string> result = new List<string>();
            foreach (IWebElement selectedOption in selectedOptions)
            {
                result.Add(selectedOption.Text);
            }
            return result;

        }

        public class SeleniumCustomMethods2
        {
            public static void Click(IWebElement locator)
            {
                locator.Click();
            }

            public static void EnterText(IWebElement locator, string text)
            {
                locator.Clear();
                locator.SendKeys(text);
            }

            public static void SelectDropDownByText(IWebElement locator, string text)
            {
                SelectElement selectElement = new SelectElement(locator);
                selectElement.SelectByText(text);
            }

            public static void SelectDropDownByValue(IWebElement locator, string text)
            {
                SelectElement selectElement = new SelectElement(locator);
                selectElement.SelectByValue(text);
            }

            public static void MultipleSelectElements(IWebElement locator, string[] values)
            {
                SelectElement multSelect = new SelectElement(locator);
                foreach (string value in values)
                {
                    multSelect.SelectByValue(value);
                }
            }
            public static List<string> GetAllSelectedList(IWebElement locator)
            {
                SelectElement multiSelect = new SelectElement(locator);
                IList<IWebElement> selectedOptions = multiSelect.AllSelectedOptions;
                List<string> result = new List<string>();
                foreach (IWebElement selectedOption in selectedOptions)
                {
                    result.Add(selectedOption.Text);
                }
                return result;

            }
        }
    }
}

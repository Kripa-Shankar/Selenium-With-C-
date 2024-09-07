using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotNetSelenium
{
 

        public static class SeleniumCustomMethods
        {
            public static void Click(this IWebElement locator)
            {
                locator.Click();
            }
        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(this IWebElement locator, string text)
            {
                locator.Clear();
                locator.SendKeys(text);
            }

            public static void SelectDropDownByText(this IWebElement locator, string text)
            {
                SelectElement selectElement = new SelectElement(locator);
                selectElement.SelectByText(text);
            }

            public static void SelectDropDownByValue(this IWebElement locator, string text)
            {
                SelectElement selectElement = new SelectElement(locator);
                selectElement.SelectByValue(text);
            }

            public static void MultipleSelectElements(this IWebElement locator, string[] values)
            {
                SelectElement multSelect = new SelectElement(locator);
                foreach (string value in values)
                {
                    multSelect.SelectByValue(value);
                }
            }
            public static List<string> GetAllSelectedList(this IWebElement locator)
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


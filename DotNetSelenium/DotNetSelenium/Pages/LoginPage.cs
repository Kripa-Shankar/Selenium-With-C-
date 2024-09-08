using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotNetSelenium.SeleniumCustomMethods;

namespace DotNetSelenium.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
            this.driver= driver;
        }
        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));

        IWebElement TxtUserName => driver.FindElement(By.Id("UserName"));

        IWebElement TxtPassword => driver.FindElement(By.Id("Password"));

        IWebElement BtnLogin => driver.FindElement(By.CssSelector(".btn"));

        IWebElement LnkEmployeeDetails => driver.FindElement(By.LinkText("Employee Details"));
        IWebElement LnkManageUsers => driver.FindElement(By.LinkText("Manage Users"));
        IWebElement LnkLogOff => driver.FindElement(By.LinkText("Log off"));

        public void ClickLogin()
        {
            LoginLink.Click();

            //SeleniumCustomMethods2.Click(LoginLink);
        }
        public void Login(string username, string password)
        {
            //TxtUserName.SendKeys(username);
            //TxtPassword.SendKeys(password);

            //BtnLogin.Submit();

            //SeleniumCustomMethods2.EnterText(TxtUserName, "admin");
            //SeleniumCustomMethods2.EnterText(TxtPassword, "password");
            //SeleniumCustomMethods2.Click(BtnLogin);


            TxtUserName.EnterText(username);
            TxtPassword.EnterText(password);
            BtnLogin.Submit();
        }

        public bool IsLoggegInd()
        {
            return LnkEmployeeDetails.Displayed;
        }
    }
}

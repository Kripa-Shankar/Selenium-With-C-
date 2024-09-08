using DotNetSelenium.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSelenium
{
    public class DataDrivenTesting
    {
        private IWebDriver _driver;
      
        
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(Login))]
        public void TestUsingPOM(LoginModel loginModel)
        {

            LoginPage loginPage = new LoginPage(_driver);

            loginPage.ClickLogin();

            loginPage.Login(loginModel.UserName, loginModel.Password);
        }

        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            {
                UserName = "admin",
                Password = "password"
            };

            yield return new LoginModel()
            {
                UserName = "admin2",
                Password = "password2"
            };

            yield return new LoginModel()
            {
                UserName = "admin3",
                Password = "password3"
            };
        }
        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();

                
                _driver.Dispose();
            }
        }





    }
}

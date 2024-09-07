using DotNetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //1.Create a new instance of a Selenium WebDriver
            IWebDriver driver = new ChromeDriver();

            //2. Navigate to the URL
            driver.Navigate().GoToUrl("https://www.google.co.in/");

            //2a. Maximize the browser Window

            driver.Manage().Window.Maximize();

            //3. Find the Element
            IWebElement webElement = driver.FindElement(By.Name("q"));

            //4.Type in the element

            webElement.SendKeys("Selenium");

            //5. Click on the element
            webElement.SendKeys(Keys.Return);

        }

        [Test]
        public void EaWebTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://eaapp.somee.com");

            driver.Manage().Window.Maximize();

            //IWebElement loginElement = driver.FindElement(By.Id("loginLink"));

            //loginElement.SendKeys(Keys.Return);

            //var loginLink = driver.FindElement(By.LinkText("Login"));
            //loginLink.Click();

           //driver.FindElement(By.LinkText("Login")).Click();

            //SeleniumCustomMethods.Click(driver, By.Id("loginLink"));

            //IWebElement txtUserName = driver.FindElement(By.Id("UserName"));
            //txtUserName.SendKeys("admin");

            //SeleniumCustomMethods.EnterText(driver, By.Id("UserName"), "admin");

            //IWebElement txtPassword = driver.FindElement(By.Name("Password"));
            //txtPassword.SendKeys("password");

            //SeleniumCustomMethods.EnterText(driver, By.Name("Password"), "password");

            IWebElement btnLogin = driver.FindElement(By.ClassName("btn"));
            btnLogin.Submit();


        }

        [Test]
        //Page Object Model ->POM
        public void TestUsingPOM()
        {
            IWebDriver driver= new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com");

            //POM Initialization

            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLogin();

            loginPage.Login("admin", "password");



        }
    }
}
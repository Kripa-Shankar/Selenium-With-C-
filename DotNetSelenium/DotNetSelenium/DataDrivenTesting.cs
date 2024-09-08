using DotNetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

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
            //ReadJsonFile();
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void TestUsingPOM(LoginModel loginModel)
        {
            //Arrange Opereation
            LoginPage loginPage = new LoginPage(_driver);

            //Act Operations
            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);

            //Assert

            var getLoggedIn=loginPage.IsLoggegInd();
            Assert.IsTrue(getLoggedIn);

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


        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);

            foreach (var loginData in loginModel)
            {
                yield return loginData;

            }
        }


        private void ReadJsonFile()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            string jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

            Console.WriteLine($"UserName: {loginModel.UserName} Password: {loginModel.Password}");
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

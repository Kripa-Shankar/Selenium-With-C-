using DotNetSelenium.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSelenium
{
    public class NUnitTestDemo
    {
        private  IWebDriver _driver;

    //the SetUp attribute is used to denote methods that should be executed before each test in a test class. 
    //It is a way to set up any necessary context or state before the test methods are run.
    //This can be useful for initializing objects, configuring settings, or preparing the
    //environment required for tests.

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestUsingPOM()
        {
          
            LoginPage loginPage = new LoginPage(_driver);

            loginPage.ClickLogin();

            loginPage.Login("admin", "password");
        }

        //The[TearDown] attribute in NUnit is used to designate a method that should be executed after 4
        //each test method in the test class. 
        //It is typically used for cleanup operations, such as closing browser windows or disposing of resources.

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();

                //Dispose is used to release unmanaged resources held by an object.
                _driver.Dispose(); 
            }
        }


    }
}

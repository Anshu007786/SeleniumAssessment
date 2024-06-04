using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace WebAppTests
{
    [TestClass]
    public class WebAppTests
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void TestPageLoadsSuccessfully()
        {
            _driver.Navigate().GoToUrl("http://localhost:5159/");
            Assert.IsTrue(_driver.Title.Contains("Home Page"));
        }

        [TestMethod]
        public void TestFormSubmission()
        {
            _driver.Navigate().GoToUrl("http://localhost:5159/");

            _driver.FindElement(By.Id("Name")).SendKeys("Random 1");
            _driver.FindElement(By.Id("Email")).SendKeys("random.one@example.com");
            _driver.FindElement(By.Id("Phone")).SendKeys("1234567890");
            _driver.FindElement(By.Id("CompanyName")).SendKeys("");

            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            var message = _driver.FindElement(By.TagName("p")).Text;
            Assert.AreEqual("Welcome, Random 1!", message);
        }

        [TestMethod]
        public void TestFormSubmissionWithDelay()
        {
            _driver.Navigate().GoToUrl("http://localhost:5159/");

            _driver.FindElement(By.Id("Name")).SendKeys("Random 2");
            _driver.FindElement(By.Id("Email")).SendKeys("random.two@example.com");
            _driver.FindElement(By.Id("Phone")).SendKeys("0987654321");
            _driver.FindElement(By.Id("CompanyName")).SendKeys("");

            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Simulate a delay in displaying the welcome message
            Thread.Sleep(3000);

            var message = _driver.FindElement(By.TagName("p")).Text;
            Assert.AreEqual("Welcome, Random 2!", message);
        }
    }
}

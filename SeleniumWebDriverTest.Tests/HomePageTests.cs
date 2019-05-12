using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace SeleniumWebDriverTest.Tests
{
    [TestClass]
    public class HomePageTests
    {
        public static readonly string baseUrl = "http://localhost:5000";
        private FirefoxDriver _driver;
        [TestInitialize]
        public void Initialize()
        {
            _driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
        }
        [TestMethod]
        public void TestingCookieConsentButton_IsVisible()
        {
            _driver.Navigate().GoToUrl(baseUrl);
            var cookie = _driver.FindElementById("cookieConsent");
            Assert.IsTrue(cookie.Displayed);
            Assert.IsFalse(cookie.Size.IsEmpty);
            var cookieAccept = cookie.FindElement(By.TagName("button"));
            cookieAccept.Click();
            Assert.ThrowsException<NoSuchElementException>(() => {
                _driver.FindElementById("cookieConsent");
            });
            _driver.Navigate().Refresh();
            Assert.ThrowsException<NoSuchElementException>(() => {
                _driver.FindElementById("cookieConsent");
            });
        }
        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}

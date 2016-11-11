﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Selenium.WebDriver.Equip.Tests
{
    [TestFixture]
    [Category(TestCategories.LocalDriver)]
    public class IWebDriverFactoryTests
    {
        private IWebDriver _driver;
        [SetUp]
        public void SetupTest()
        {
        }

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Quit();
            }
        }

        [Ignore("")]
        [Test]
        public void GetFirefoxBrowserTest()
        {
            _driver = WebDriverFactory.GetBrowser<FirefoxDriver>("http://rickcasady.blogspot.com/");
            Assert.AreEqual(typeof(FirefoxDriver), _driver.GetType());
        }

        [Test]
        public void GetInternetExplorerBrowserTest()
        {
            Assume.That(_driver.GetNuGetIEDriver());
            _driver = WebDriverFactory.GetBrowser<InternetExplorerDriver>("http://rickcasady.blogspot.com/");
            Assert.AreEqual(typeof(InternetExplorerDriver), _driver.GetType());
        }

        [Test]
        public void GetChromeBrowserTest()
        {
            Assume.That(_driver.GetNuGetChromeDriver());
            _driver = WebDriverFactory.GetBrowser<ChromeDriver>("http://rickcasady.blogspot.com/");
            Assert.AreEqual(typeof(ChromeDriver), _driver.GetType());
        }
    }
}

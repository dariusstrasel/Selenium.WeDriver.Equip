﻿using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;

namespace Selenium.WebDriver.Equip.Tests
{
    /// <summary>
    /// A base fixture for Selenium testing single browser per test
    /// </summary>
    [TestFixture]
    public class BaseTest
    {
        /// <summary>
        /// Instance of the browser used for the test
        /// </summary>
        public IWebDriver Driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            if (EnvironmentManager.Instance.Browser == Browser.Remote)
                EnvironmentManager.Instance.RemoteServer.Start();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            EnvironmentManager.Instance.CloseCurrentDriver();
            if (EnvironmentManager.Instance.Browser == Browser.Remote)
                EnvironmentManager.Instance.RemoteServer.Stop();
        }

        /// <summary>
        /// Initialize the browser before the test starts
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            Driver = EnvironmentManager.Instance.CreateDriverInstance(TestContext.CurrentContext.Test.Name);
        }

        /// <summary>
        /// Dereference the instance of the browser
        /// Takes screenshot and gets page source when failure occurs 
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                var outcome = TestContext.CurrentContext.Result.Outcome == ResultState.Success;
                if (!outcome)
                    new TestCapture(Driver, TestContext.CurrentContext.Test.GetCleanName() + ".Failed").CaptureWebPage();
                EnvironmentManager.Instance.CloseCurrentDriver(outcome);
                Driver = null;
            }
        }
    }
}

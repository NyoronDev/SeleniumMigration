using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Reflection;

namespace CepsaMigration.Core.Selenium.SetUp
{
    /// <summary>
    /// The SetUp selenium webdriver interface.
    /// </summary>
    public interface ISetUpSeleniumWebDriver
    {
        /// <summary>
        /// Sets up chrome web driver.
        /// </summary>
        /// <returns></returns>
        IWebDriver SetUpChromeWebDriver();
    }

    /// <summary>
    /// The SetUp selenium webdriver class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.SetUp.ISetUpSeleniumWebDriver" />
    public class SetUpSeleniumWebDriver : ISetUpSeleniumWebDriver
    {
        private const string WebDriverPath = @"..\..\..\CepsaMigration.Core.Selenium.SetUp\binaries\";

        /// <summary>
        /// Gets the web driver.
        /// </summary>
        /// <value>
        /// The web driver.
        /// </value>
        private static IWebDriver _webDriver { get; set; }

        /// <summary>
        /// Sets up chrome web driver.
        /// </summary>
        public IWebDriver SetUpChromeWebDriver()
        {
            if (_webDriver != null)
            {
                return _webDriver;
            }

            _webDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(WebDriverPath),
                new ChromeOptions(), TimeSpan.FromSeconds(30));

            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);

            return _webDriver;
        }
    }
}

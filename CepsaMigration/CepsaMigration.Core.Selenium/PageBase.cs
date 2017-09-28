using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Core.Selenium.SetUp;
using OpenQA.Selenium;

namespace CepsaMigration.Core.Selenium
{
    /// <summary>
    /// The page base class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IPageBase" />
    public class PageBase : IPageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageBase"/> class.
        /// </summary>
        /// <param name="setUpSeleniumWebDriver">The set up selenium web driver.</param>
        public PageBase(ISetUpSeleniumWebDriver setUpSeleniumWebDriver)
        {
            WebDriver = setUpSeleniumWebDriver.SetUpChromeWebDriver();
        }

        /// <summary>
        /// Gets or sets the web driver.
        /// </summary>
        /// <value>
        /// The web driver.
        /// </value>
        protected IWebDriver WebDriver { get; set; }
    }
}

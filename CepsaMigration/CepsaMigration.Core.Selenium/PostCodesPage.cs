using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Core.Selenium.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace CepsaMigration.Core.Selenium
{
    /// <summary>
    /// The post codes page class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.PageBase" />
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IPostCodesPage" />
    public class PostCodesPage : PageBase, IPostCodesPage
    {
        #region .: Web Elements :.

        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement _searchButton;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PostCodesPage"/> class.
        /// </summary>
        /// <param name="setUpSeleniumWebDriver">The set up selenium web driver.</param>
        public PostCodesPage(ISetUpSeleniumWebDriver setUpSeleniumWebDriver) 
            : base(setUpSeleniumWebDriver)
        {
        }

        /// <summary>
        /// Searches the post codes.
        /// </summary>
        public void SearchPostCodes()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            WebDriver.SwitchTo().Frame("criteria_Usuarios");
            PageFactory.InitElements(WebDriver, this);

            _searchButton.Click();
        }
    }
}

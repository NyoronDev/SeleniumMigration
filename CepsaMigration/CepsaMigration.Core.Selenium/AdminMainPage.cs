using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Core.Selenium.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace CepsaMigration.Core.Selenium
{
    /// <summary>
    /// The admin main page class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.PageBase" />
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IAdminMainPage" />
    public class AdminMainPage : PageBase, IAdminMainPage
    {
        #region .: Web Elements :.

        [FindsBy(How = How.Id, Using = "adminMainAppWrapper")]
        private IWebElement _adminMainContent;

        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement _searchContent;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminMainPage"/> class.
        /// </summary>
        /// <param name="setUpSeleniumWebDriver">The set up selenium web driver.</param>
        public AdminMainPage(ISetUpSeleniumWebDriver setUpSeleniumWebDriver) 
            : base(setUpSeleniumWebDriver)
        {
            PageFactory.InitElements(WebDriver, this);
        }

        /// <summary>
        /// Clicks the users.
        /// </summary>
        public void ClickUsers()
        {
            Thread.Sleep(TimeSpan.FromSeconds(13));

            var action = new Actions(WebDriver);
            action.MoveToElement(_adminMainContent).MoveByOffset(-350, -350).Click().Build().Perform();
        }

        /// <summary>
        /// Clicks the post codes.
        /// </summary>
        public void ClickPostCodes()
        {
            Thread.Sleep(TimeSpan.FromSeconds(4));
            var action = new Actions(WebDriver);
            action.MoveToElement(_adminMainContent).MoveByOffset(-150, -117).Click().Build().Perform();
        }

        /// <summary>
        /// Clicks the profile page.
        /// </summary>
        public void ClickProfilePage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            WebDriver.SwitchTo().DefaultContent();

            var action = new Actions(WebDriver);
            action.MoveToElement(_adminMainContent).MoveByOffset(-150, -10).Click().Build().Perform();
        }
    }
}

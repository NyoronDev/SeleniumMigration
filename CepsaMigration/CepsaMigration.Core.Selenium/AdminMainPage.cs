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
        /// <param name="isFirstTimeUser">if set to <c>true</c> [is first time user].</param>
        public void ClickUsers(bool isFirstTimeUser)
        {
            if (isFirstTimeUser)
            {
                Thread.Sleep(TimeSpan.FromSeconds(13));
            }
            else
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            
            WebDriver.SwitchTo().DefaultContent();
            PageFactory.InitElements(WebDriver, this);

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
            action.MoveToElement(_adminMainContent).MoveByOffset(-150, -90).Click().Build().Perform();
        }

        /// <summary>
        /// Clicks the profile page.
        /// </summary>
        public void ClickProfilePage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            WebDriver.SwitchTo().DefaultContent();

            var action = new Actions(WebDriver);
            action.MoveToElement(_adminMainContent).MoveByOffset(-150, 0).Click().Build().Perform();
        }

        /// <summary>
        /// Clicks the study programs.
        /// </summary>
        public void ClickStudyPrograms()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));

            WebDriver.SwitchTo().DefaultContent();

            var action = new Actions(WebDriver);
            action.MoveToElement(_adminMainContent).MoveByOffset(-150, 65).Click().Build().Perform();
        }
    }
}

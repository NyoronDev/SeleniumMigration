using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Core.Selenium.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace CepsaMigration.Core.Selenium
{
    /// <summary>
    /// The add profile page.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.PageBase" />
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IAddProfilePage" />
    public class AddProfilePage : PageBase, IAddProfilePage
    {
        #region .: Web Elements :.

        [FindsBy(How = How.Id, Using = "ppId")]
        private IWebElement _profileTextBox;

        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="AddProfilePage"/> class.
        /// </summary>
        /// <param name="setUpSeleniumWebDriver">The set up selenium web driver.</param>
        public AddProfilePage(ISetUpSeleniumWebDriver setUpSeleniumWebDriver) 
            : base(setUpSeleniumWebDriver)
        {
        }

        /// <summary>
        /// Adds the profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        public void AddProfileId(string profileId)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            WebDriver.SwitchTo().Frame(3);
            PageFactory.InitElements(WebDriver, this);

            var profileSubmitButton = WebDriver.FindElements(By.Id("submitbutton"))[0];

            _profileTextBox.SendKeys(profileId);
            profileSubmitButton.Click();
        }

        /// <summary>
        /// Applies the changes.
        /// </summary>
        public void ApplyChanges()
        {
            var profileSubmitButton = WebDriver.FindElements(By.Id("submitbutton"))[1];
            profileSubmitButton.Click();
        }
    }
}

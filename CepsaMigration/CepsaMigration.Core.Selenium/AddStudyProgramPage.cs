using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Core.Selenium.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace CepsaMigration.Core.Selenium
{
    /// <summary>
    /// The Add study program page class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.PageBase" />
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IAddStudyProgramPage" />
    public class AddStudyProgramPage : PageBase, IAddStudyProgramPage
    {
        #region .: Web Elements :.

        [FindsBy(How = How.Id, Using = "qualId")]
        private IWebElement _studyProgramTextBox;

        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="AddStudyProgramPage"/> class.
        /// </summary>
        /// <param name="setUpSeleniumWebDriver">The set up selenium web driver.</param>
        public AddStudyProgramPage(ISetUpSeleniumWebDriver setUpSeleniumWebDriver) 
            : base(setUpSeleniumWebDriver)
        {
        }

        /// <summary>
        /// Adds the study program identifier.
        /// </summary>
        /// <param name="programId">The program identifier.</param>
        /// <param name="isFirstTime">if set to <c>true</c> [is first time].</param>
        public void AddStudyProgramId(string programId, bool isFirstTime)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            if (isFirstTime)
            {
                WebDriver.SwitchTo().Frame(3);
                PageFactory.InitElements(WebDriver, this);
            }

            _studyProgramTextBox.SendKeys(programId);

            Thread.Sleep(TimeSpan.FromSeconds(1));

            _studyProgramTextBox.SendKeys(Keys.Enter);
        }
    }
}

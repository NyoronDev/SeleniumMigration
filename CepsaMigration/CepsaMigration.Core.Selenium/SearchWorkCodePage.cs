using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Core.Selenium.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace CepsaMigration.Core.Selenium
{
    /// <summary>
    /// The work codes page class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.PageBase" />
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.ISearchWorkCodePage" />
    public class SearchWorkCodePage : PageBase, ISearchWorkCodePage
    {
        #region .: Web Elements :.

        [FindsBy(How = How.Id, Using = "ID_Match")]
        private IWebElement _idMatchSelect;

        [FindsBy(How = How.Id, Using = "ID")]
        private IWebElement _idPostCodeTextBox;

        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement _searchButton;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchWorkCodePage"/> class.
        /// </summary>
        /// <param name="setUpSeleniumWebDriver">The set up selenium web driver.</param>
        public SearchWorkCodePage(ISetUpSeleniumWebDriver setUpSeleniumWebDriver) 
            : base(setUpSeleniumWebDriver)
        {
        }

        /// <summary>
        /// Searches the work code.
        /// </summary>
        /// <param name="postCode">The post code.</param>
        public void SearchWorkCode(string postCode)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            WebDriver.SwitchTo().Frame("criteria_Usuarios");
            PageFactory.InitElements(WebDriver, this);

            // Select exact work code ID
            _idMatchSelect.Click();
            foreach (var element in _idMatchSelect.FindElements(By.TagName("option")))
            {
                if (element.Text == "Exacto")
                {
                    element.Click();
                }
            }

            _idPostCodeTextBox.SendKeys(postCode);

            // Click Search Button
            _searchButton.Click();

            // Click edit work code
            Thread.Sleep(TimeSpan.FromSeconds(2));

            WebDriver.SwitchTo().Frame("getPathBuffer");

            WebDriver.FindElements(By.XPath("//a[contains(@class, 'auto_edit')]"))[0].Click();
        }
    }
}

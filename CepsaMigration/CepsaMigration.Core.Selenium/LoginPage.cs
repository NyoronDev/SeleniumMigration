using CepsaMigration.Core.Selenium.Contracts;
using CepsaMigration.Core.Selenium.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CepsaMigration.Core.Selenium
{
    /// <summary>
    /// The login page class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.PageBase" />
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.ILoginPage" />
    public class LoginPage : PageBase, ILoginPage
    {
        private const string WebDirection = "https://cepsa-stage.plateau.com/learning/admin/nativelogin.jsp";

        #region .: Web Elements :.

        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement _userNameInput;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.Name, Using = "submit")]
        private IWebElement _submitButton;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="setUpSeleniumWebDriver">The set up selenium web driver.</param>
        public LoginPage(ISetUpSeleniumWebDriver setUpSeleniumWebDriver)
            : base(setUpSeleniumWebDriver)
        {
            PageFactory.InitElements(WebDriver, this);
        }

        /// <summary>
        /// Goes to login page.
        /// </summary>
        public void GoToLoginPage()
        {
            WebDriver.Navigate().GoToUrl(WebDirection);
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        public void LoginUser(string user, string password)
        {
            _userNameInput.SendKeys(user);
            _passwordInput.SendKeys(password);
            _submitButton.Click();
        }
    }
}

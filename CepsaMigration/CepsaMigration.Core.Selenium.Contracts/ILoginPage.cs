namespace CepsaMigration.Core.Selenium.Contracts
{
    /// <summary>
    /// The Login page interface.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IPageBase" />
    public interface ILoginPage : IPageBase
    {
        /// <summary>
        /// Goes to login page.
        /// </summary>
        void GoToLoginPage();

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        void LoginUser(string user, string password);
    }
}

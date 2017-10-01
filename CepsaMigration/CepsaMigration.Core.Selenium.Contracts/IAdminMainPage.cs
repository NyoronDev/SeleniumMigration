namespace CepsaMigration.Core.Selenium.Contracts
{
    /// <summary>
    /// The admin main page interface.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IPageBase" />
    public interface IAdminMainPage : IPageBase
    {
        /// <summary>
        /// Clicks the users.
        /// </summary>
        /// <param name="isFirstTimeUser">if set to <c>true</c> [is first time user].</param>
        void ClickUsers(bool isFirstTimeUser);

        /// <summary>
        /// Clicks the post codes.
        /// </summary>
        void ClickPostCodes();

        /// <summary>
        /// Clicks the profile page.
        /// </summary>
        void ClickProfilePage();
    }
}

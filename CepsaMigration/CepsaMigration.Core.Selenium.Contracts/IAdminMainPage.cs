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
        void ClickUsers();

        /// <summary>
        /// Clicks the post codes.
        /// </summary>
        void ClickPostCodes();
    }
}

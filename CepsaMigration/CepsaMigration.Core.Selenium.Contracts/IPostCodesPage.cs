namespace CepsaMigration.Core.Selenium.Contracts
{
    /// <summary>
    /// The post codes page interface.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IPageBase" />
    public interface IPostCodesPage : IPageBase
    {
        /// <summary>
        /// Searches the post codes.
        /// </summary>
        void SearchPostCodes();
    }
}

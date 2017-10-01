namespace CepsaMigration.Core.Selenium.Contracts
{
    /// <summary>
    /// The post codes page interface.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IPageBase" />
    public interface ISearchWorkCodePage : IPageBase
    {
        /// <summary>
        /// Searches the post codes.
        /// </summary>
        /// <param name="postCode">The post code.</param>
        void SearchPostCode(string postCode);
    }
}

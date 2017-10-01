namespace CepsaMigration.Core.Selenium.Contracts
{
    /// <summary>
    /// The add profile page interface.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IPageBase" />
    public interface IAddProfilePage : IPageBase
    {    
        /// <summary>
        /// Adds the profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        void AddProfileId(string profileId);

        /// <summary>
        /// Applies the changes.
        /// </summary>
        void ApplyChanges();
    }
}

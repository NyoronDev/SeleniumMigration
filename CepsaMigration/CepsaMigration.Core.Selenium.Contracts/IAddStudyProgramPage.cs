namespace CepsaMigration.Core.Selenium.Contracts
{
    /// <summary>
    /// The add study program page interface.
    /// </summary>
    /// <seealso cref="CepsaMigration.Core.Selenium.Contracts.IPageBase" />
    public interface IAddStudyProgramPage : IPageBase
    {
        /// <summary>
        /// Adds the study program identifier.
        /// </summary>
        /// <param name="programId">The program identifier.</param>
        /// <param name="isFirstTime">if set to <c>true</c> [is first time].</param>
        void AddStudyProgramId(string programId, bool isFirstTime);
    }
}

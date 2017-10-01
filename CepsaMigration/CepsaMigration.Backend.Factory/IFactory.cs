using CepsaMigration.Data.DataService.Contracts;

namespace CepsaMigration.Backend.Factory
{
    /// <summary>
    /// The factory interface.
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Gets the work code data service.
        /// </summary>
        /// <returns></returns>
        IWorkCodeDataService GetWorkCodeDataService();
    }
}

using CepsaMigration.Data.DataService.Contracts;

namespace CepsaMigration.Backend.Factory
{
    /// <summary>
    /// The factory class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Backend.Factory.IFactory" />
    public class Factory : IFactory
    {
        private readonly IWorkCodeDataService _workCodeDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        /// <param name="workCodeDataService">The work code data service.</param>
        public Factory(IWorkCodeDataService workCodeDataService)
        {
            _workCodeDataService = workCodeDataService;
        }

        /// <summary>
        /// Gets the work code data service.
        /// </summary>
        /// <returns></returns>
        public IWorkCodeDataService GetWorkCodeDataService()
        {
            return _workCodeDataService;
        }
    }
}

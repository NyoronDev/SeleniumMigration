using System.Collections.Generic;

namespace CepsaMigration.Data.Entities
{
    /// <summary>
    /// The Work Code entity.
    /// </summary>
    public class WorkCodeEntity
    {
        /// <summary>
        /// Gets or sets the work code.
        /// </summary>
        /// <value>
        /// The work code.
        /// </value>
        public string WorkCodeId { get; set; }

        public IList<string> Profiles { get; set; }
    }
}

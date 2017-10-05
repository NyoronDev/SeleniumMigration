using CepsaMigration.Data.TypeSafeEnum;
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

        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        public DataType DataType { get; set; } 

        /// <summary>
        /// Gets or sets the study programs.
        /// </summary>
        /// <value>
        /// The study programs.
        /// </value>
        public IList<string> StudyPrograms { get; set; }
    }
}

using CepsaMigration.Data.Entities;
using System;
using System.Collections.Generic;

namespace CepsaMigration.Data.DataService.Contracts
{
    /// <summary>
    /// The work code data service.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IWorkCodeDataService : IDisposable
    {
        /// <summary>
        /// Obtains the work code list.
        /// </summary>
        /// <returns></returns>
        IList<WorkCodeEntity> ObtainWorkCodeList();
    }
}

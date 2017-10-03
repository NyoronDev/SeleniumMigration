using CepsaMigration.Data.DataService.Contracts;
using CepsaMigration.Data.Entities;
using System.Collections.Generic;

namespace CepsaMigration.Data.DataService
{
    /// <summary>
    /// The WorkCode data service class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Data.DataService.Contracts.IWorkCodeDataService" />
    public class WorkCodeDataService : IWorkCodeDataService
    {
        /// <summary>
        /// Obtains the work code list.
        /// </summary>
        /// <returns></returns>
        public IList<WorkCodeEntity> ObtainWorkCodeList()
        {
            var workCodeEntity = new List<WorkCodeEntity>();
            workCodeEntity.Add(new WorkCodeEntity
            {
                WorkCodeId = "Analista Aplicación",
                StudyPrograms = new List<string> { "1", "10" }
            });

            workCodeEntity.Add(new WorkCodeEntity
            {
                WorkCodeId = "Analista Calidad",
                StudyPrograms = new List<string> { "123456", "2345", "5" }
            });

            return workCodeEntity;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            // TODO - Create the Dispose method.
        }
    }
}

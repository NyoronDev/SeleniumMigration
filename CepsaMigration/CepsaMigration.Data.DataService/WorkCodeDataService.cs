using CepsaMigration.Data.DataService.Contracts;
using CepsaMigration.Data.Entities;
using CepsaMigration.Data.TypeSafeEnum;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CepsaMigration.Data.DataService
{
    /// <summary>
    /// The WorkCode data service class.
    /// </summary>
    /// <seealso cref="CepsaMigration.Data.DataService.Contracts.IWorkCodeDataService" />
    public class WorkCodeDataService : IWorkCodeDataService
    {
        private const string DataExcelPath = @"..\..\..\CepsaMigration.Data.DataService\Data\DataMigrate.xlsx";

        /// <summary>
        /// Obtains the work code list.
        /// </summary>
        /// <returns></returns>
        public IList<WorkCodeEntity> ObtainWorkCodeList()
        {
            var workCodeEntityList = new List<WorkCodeEntity>();

            using (var fileStream = new FileStream(DataExcelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var spreadsheetDocument = SpreadsheetDocument.Open(fileStream, false))
                {
                    var workbookPart = spreadsheetDocument.WorkbookPart;
                    var sharedStringPart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                    var sharedStringTable = sharedStringPart.SharedStringTable;

                    var worksheetPart = workbookPart.WorksheetParts.First();
                    var sheet = worksheetPart.Worksheet;

                    var cells = sheet.Descendants<Cell>();
                    var rows = sheet.Descendants<Row>();

                    foreach (var row in rows)
                    {
                        var workCodeEntity = new WorkCodeEntity();
                        workCodeEntity.StudyPrograms = new List<string>();

                        foreach (var cell in row.Elements<Cell>())
                        {
                            var text = string.Empty;

                            // String cell value.
                            if (cell.DataType != null && cell.DataType == CellValues.SharedString)
                            {
                                    var id = int.Parse(cell.CellValue.Text);
                                    text = sharedStringTable.ChildElements[id].InnerText;
                            }
                            // Integer cell value.
                            else
                            {
                                if (cell.CellValue != null && !string.IsNullOrEmpty(cell.CellValue.Text))
                                {
                                    text = cell.CellValue.Text;
                                }
                            }

                            if (cell.CellReference.Value.Contains("A"))
                            {
                                workCodeEntity.WorkCodeId = text;
                            }
                            else if (cell.CellReference.Value.Contains("B"))
                            {
                                workCodeEntity.DataType = DataType.GetDataType(text);
                            }
                            else
                            {
                                workCodeEntity.StudyPrograms.Add(text);
                            }
                        }

                        workCodeEntityList.Add(workCodeEntity);
                    }
                }
            }

            return workCodeEntityList;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}

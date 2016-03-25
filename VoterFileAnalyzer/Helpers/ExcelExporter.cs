using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoterFileAnalyzer
{
    class ExcelExporter
    {
        public static void ExcelGenerator(DataTable dataToExcel, string excelSheetName, string FilePath)
        {

            //Uses the EPPlus Package:  http://epplus.codeplex.com/downloads/get/418378
            //This is adapted from http://bytesofcode.hubpages.com/hub/Export-DataSet-and-DataTable-to-Excel-2007-in-C
          


            var newFile = new FileInfo(FilePath);

            //Step 1 : Create object of ExcelPackage class and pass file path to constructor.
            using (var package = new ExcelPackage(newFile))
            {
                //Step 2 : Add a new worksheet to ExcelPackage object and give a suitable name

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(excelSheetName);

                //Step 3 : Start loading datatable from A1 cell of worksheet.
                worksheet.Cells["A1"].LoadFromDataTable(dataToExcel, true, TableStyles.None);
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                //Look for DateTime columns and set them appropriately
                var rowCount = dataToExcel.Rows.Count;
                var dateColumns = from DataColumn d in dataToExcel.Columns
                                  where d.DataType == typeof(DateTime) || d.ColumnName.Contains("Date")
                                  select d.Ordinal + 1;
                foreach (var dc in dateColumns)
                {
                    worksheet.Cells[2, dc, rowCount + 1, dc].Style.Numberformat.Format = "mm/dd/yyyy";
                }


                //Step 4 : (Optional) Set the file properties like title, author and subject
                package.Workbook.Properties.Title = "Florida Voter File Analyzer";
                package.Workbook.Properties.Author = "by Josh Bula";
                package.Workbook.Properties.Subject = "";

                //Step 5 : Save all changes to ExcelPackage object which will create Excel 2007 file.
                package.Save();
            }
        }
    }
}

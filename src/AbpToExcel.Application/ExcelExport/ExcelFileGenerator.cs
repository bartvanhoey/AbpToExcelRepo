using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace AbpToExcel.ExcelExport
{
    public static class ExcelFileGenerator
    {
        public static byte[] GenerateExcelFile()
        {
            var memoryStream = new MemoryStream();

            using var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook);
            var workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            var sheets = workbookPart.Workbook.AppendChild(new Sheets());

            sheets.AppendChild(new Sheet
            {
                Id = workbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "Sheet 1"
            });

            var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

            var row1 = new Row();
            row1.AppendChild(
                new Cell
                {
                    CellValue = new CellValue("Abp Framework"),
                    DataType = CellValues.String
                }

            );
            
            sheetData?.AppendChild(row1);

            var row2 = new Row();
            row2.AppendChild(
                new Cell
                {
                    CellValue = new CellValue("Open Source"),
                    DataType = CellValues.String
                }
            );
            sheetData?.AppendChild(row2);

            var row3 = new Row();
            row3.AppendChild(
                new Cell
                {
                    CellValue = new CellValue("WEB APPLICATION FRAMEWORK"),
                    DataType = CellValues.String
                }
            );
            sheetData?.AppendChild(row3);

            document.Save();
            document.Close();

            return memoryStream.ToArray();
        }
    }
}
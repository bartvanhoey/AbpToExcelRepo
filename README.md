# How to export Excel files from the ABP framework

## Create the ExportToExcelAppService ApplicationService

* Create a new folder **ExcelExport** in the **Application.Contracts** project

* Add a new **IExportToExcelAppService.cs** file to the **ExcelExport** folder with following content

```csharp
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpToExcel.Application.Contracts.ExcelExport
{
    public interface IExportToExcelAppService  : IApplicationService
    {
          Task<byte[]> ExportToExcel();
    }
}

```

* Create a new **ExcelExport** folder in the **Application** project

* Open a command prompt in the **Application** project and run the following command to install the necessary nuget packages

```bash
dotnet add package documentformat.openxml
dotnet add package documentformat.openxml.packaging
dotnet add package documentformat.openxml.spreadsheet
```

* Add a new file **ExcelFileGenerator.cs** to the **ExcelExport** folder and copy/paste code below

```csharp
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace AbpToExcel.Application.ExcelExport
{
    public class ExcelFileGenerator
    {
        public byte[] Generate()
        {
            var memoryStream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
            {
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
                sheetData.AppendChild(row1);

                var row2 = new Row();
                row2.AppendChild(
                    new Cell
                    {
                        CellValue = new CellValue("Open Source"),
                        DataType = CellValues.String
                    }
                );
                sheetData.AppendChild(row2);

                var row3 = new Row();
                row3.AppendChild(
                    new Cell
                    {
                        CellValue = new CellValue("WEB APPLICATION FRAMEWORK"),
                        DataType = CellValues.String
                    }
                );
                sheetData.AppendChild(row3);
                return memoryStream.ToArray();
            }
        }
    }
}

```

* Add a new **ExportToExcelAppService.cs** file to the **Application** project and copy/paste the code below

```csharp
using System.Threading.Tasks;
using AbpToExcel.Application.Contracts.ExcelExport;

namespace AbpToExcel.Application.ExcelExport
{
    public class ExportToExcelAppService : AbpToExcelAppService, IExportToExcelAppService
    {
        public Task<byte[]> ExportToExcel()
        {
            var bytes = new ExcelFileGenerator().Generate();
            return Task.FromResult(bytes);
        }
    }
}

```

Run the **HttpApi.Host** application to see the export-to-excel endpoint in SwaggerUI

![swagger-ui](exporttoexcel.jpg)

## Add a javascript file needed for downloading Excel files

* Create a **js** folder to the **wwwwroot** folder of the **Blazor** project

* Add an **exportexcel.js** file to the **js** folder and copy/paste the code below

```javascript
function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}
```

* Open the **index.html** file in the **wwwwroot** folder of the **Blazor** project and add this line of code at the end

```html
<script src="js/exportexcel.js"></script>
```

## Call the IExportToExcelAppService from the Blazor project

* Replace the content in the **index.razor** file with following code

```razor
@page "/"
@using AbpToExcel.Application.Contracts.ExcelExport
@inject IExportToExcelAppService ExportToExcelAppService
@inject IJSRuntime JSRuntime

<Row Class="d-flex px-0 mx-0 mb-1">
    <Button Clicked="@(() => DownloadExcelFile())" class="p-0 ml-auto mr-2" style="background-color: transparent"
        title="Download">
        <span class="fa fa-file-excel fa-lg m-0" style="color: #008000; background-color: white;"
            aria-hidden="true"></span>
    </Button>
</Row>

 @code {
    protected async Task DownloadExcelFile()
    {
        var excelBytes = await ExportToExcelAppService.ExportToExcel();
        await JSRuntime.InvokeVoidAsync("saveAsFile", $"test_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx",
        Convert.ToBase64String(excelBytes));
    }
}
```

Run the **Blazor** project and test the download to Excel file function

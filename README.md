# How to export Excel files from an ABP Blazor application

## Introduction

In this article, I will show you  how can export data to an Excel file from the ABP framework.

### Source Code

The sample application has been developed with **Blazor** as the UI framework and **SQL Server** as the database provider.

The source code of the completed application is [available on GitHub](https://github.com/bartvanhoey/AbpToExcelRepo).

## Requirements

The following tools are needed to be able to run the solution.

- .NET 8.0 SDK
- VsCode, Visual Studio 2022 or another compatible IDE
- ABP 8.0.0
  
## Development

### Create a new Application

- Install or update the ABP CLI:

```bash
dotnet tool install -g Volo.Abp.Cli || dotnet tool update -g Volo.Abp.Cli
```

- Use the following ABP CLI command:

```bash
abp new AbpToExcel -u blazor -o AbpToExcel
```

### Open & Run the Application

- Open the solution in Visual Studio (or your favorite IDE).
- Run the `AbpToExcel.DbMigrator` application to seed the initial data.
- Run the `AbpToExcel.HttpApi.Host` application that starts the API.
- Run the `AbpToExcel.Blazor` application to start the UI.

### Create the ExportToExcelAppService ApplicationService

- Create a new folder **ExcelExport** in the **Application.Contracts** project.

- Add a new **IExportToExcelAppService.cs** file to the **ExcelExport** folder with following content.

```csharp
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpToExcel.ExcelExport
{
    public interface IExportToExcelAppService :  IApplicationService
    {
        Task<byte[]> ExportToExcel();
    }
}

```

- Open a command prompt in the **Application** project and run the following command to install the necessary NuGet packages.

```bash
    dotnet add package documentformat.openxml
```

- Create a new **ExcelExport** folder in the **Application** project.

- Add a new file **ExcelFileGenerator.cs** to the **ExcelExport** folder and copy/paste code below.

```csharp
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

            return memoryStream.ToArray();
        }
    }
}
```

- Add a new **ExportToExcelAppService.cs** file to the **Application** project and copy/paste the code below.

```csharp
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using static AbpToExcel.ExcelExport.ExcelFileGenerator;

namespace AbpToExcel.ExcelExport
{
    public class ExportToExcelAppService : ApplicationService, IExportToExcelAppService
    {
        public Task<byte[]> ExportToExcel() => Task.FromResult(GenerateExcelFile());
    }
}
```

Run the **HttpApi.Host** application to see the export-to-excel endpoint in SwaggerUI.

![swagger-ui](exporttoexcel.jpg)

## Some JavaScript to download Excel files

- Create a **js** folder to the **wwwwroot** folder of the **Blazor** project.

- Add an **exporttoexcel.js** file to the **js** folder and copy/paste the code below.

```javascript
function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = 'data:application/octet-stream;base64,' + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}
```

- Open the **index.html** file in the **wwwroot** folder of the **Blazor** project and add this line of code at the end.

```bash
<script src="js/exporttoexcel.js"></script>
```

## Call the IExportToExcelAppService from the Blazor project

- Replace the content in the **index.razor** file with the following code.

```razor
@page "/"
@using AbpToExcel.ExcelExport
@inject IExportToExcelAppService ExportToExcelAppService
@inject IJSRuntime JsRuntime

<Row Class="d-flex px-0 mx-0 mb-1">
    <Button Clicked="@(ExportToExcel)" class="p-0 ml-auto mr-2" style="background-color: transparent"
            title="Download">
        <span class="fa fa-file-excel fa-lg m-0" style="color: #008000; background-color: white;"
              aria-hidden="true">
        </span>
        Click Me!
    </Button>
</Row>

@code {
    private async Task ExportToExcel()
    {
        var excelBytes = await ExportToExcelAppService.ExportToExcel();
        await JsRuntime.InvokeVoidAsync("saveAsFile", $"test_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx",
            Convert.ToBase64String(excelBytes));
    }
}
```

### Start both the Blazor and the**HttpApi.Host**project to run the application

Run both the **HttpApi.Host** and **Blazor** applications and test the export to Excel file function.

Get the [source code](https://github.com/bartvanhoey/AbpToExcelRepo.git) on GitHub.

Enjoy and have fun!

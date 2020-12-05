using System;
using System.Threading.Tasks;
using AbpToExcel.Application.Contracts.ExcelExport;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AbpToExcel.Blazor.Pages
{    public partial class Index
    {
        // [Inject] public IJSRuntime JSRuntime { get; set; }
        // [Inject] protected IExportToExcelAppService ExportToExcelAppService { get; set; }
        
        // protected async Task DownloadExcelFile()
        // {
        //     var excelBytes = await ExportToExcelAppService.ExportToExcel();
        //     await JSRuntime.InvokeVoidAsync("saveAsFile", $"test_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx", Convert.ToBase64String(excelBytes));

        // }
    }
}
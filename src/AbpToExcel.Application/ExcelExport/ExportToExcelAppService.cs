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

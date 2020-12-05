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
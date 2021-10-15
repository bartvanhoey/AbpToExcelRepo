using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpToExcel.Application.Contracts.ExcelExport
{
    public interface IExportToExcelAppService  : IApplicationService
    {
          Task<byte[]> ExportToExcel();
    }
}


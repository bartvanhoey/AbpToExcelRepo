using AbpToExcel.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpToExcel.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpToExcelController : AbpController
    {
        protected AbpToExcelController()
        {
            LocalizationResource = typeof(AbpToExcelResource);
        }
    }
}
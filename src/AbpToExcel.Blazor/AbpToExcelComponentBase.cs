using AbpToExcel.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpToExcel.Blazor
{
    public abstract class AbpToExcelComponentBase : AbpComponentBase
    {
        protected AbpToExcelComponentBase()
        {
            LocalizationResource = typeof(AbpToExcelResource);
        }
    }
}

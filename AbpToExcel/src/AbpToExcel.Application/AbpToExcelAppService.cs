using System;
using System.Collections.Generic;
using System.Text;
using AbpToExcel.Localization;
using Volo.Abp.Application.Services;

namespace AbpToExcel
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpToExcelAppService : ApplicationService
    {
        protected AbpToExcelAppService()
        {
            LocalizationResource = typeof(AbpToExcelResource);
        }
    }
}

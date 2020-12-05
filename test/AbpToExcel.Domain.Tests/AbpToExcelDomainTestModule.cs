using AbpToExcel.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpToExcel
{
    [DependsOn(
        typeof(AbpToExcelEntityFrameworkCoreTestModule)
        )]
    public class AbpToExcelDomainTestModule : AbpModule
    {

    }
}
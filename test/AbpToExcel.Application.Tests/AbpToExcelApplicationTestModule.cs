using Volo.Abp.Modularity;

namespace AbpToExcel
{
    [DependsOn(
        typeof(AbpToExcelApplicationModule),
        typeof(AbpToExcelDomainTestModule)
        )]
    public class AbpToExcelApplicationTestModule : AbpModule
    {

    }
}
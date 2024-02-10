using Volo.Abp.Modularity;

namespace AbpToExcel;

[DependsOn(
    typeof(AbpToExcelDomainModule),
    typeof(AbpToExcelTestBaseModule)
)]
public class AbpToExcelDomainTestModule : AbpModule
{

}

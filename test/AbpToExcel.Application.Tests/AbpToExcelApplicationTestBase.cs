using Volo.Abp.Modularity;

namespace AbpToExcel;

public abstract class AbpToExcelApplicationTestBase<TStartupModule> : AbpToExcelTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

using Volo.Abp.Modularity;

namespace AbpToExcel;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpToExcelDomainTestBase<TStartupModule> : AbpToExcelTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

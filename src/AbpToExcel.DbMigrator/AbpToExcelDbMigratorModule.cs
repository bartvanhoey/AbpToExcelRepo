using AbpToExcel.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpToExcel.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpToExcelEntityFrameworkCoreModule),
    typeof(AbpToExcelApplicationContractsModule)
    )]
public class AbpToExcelDbMigratorModule : AbpModule
{
}

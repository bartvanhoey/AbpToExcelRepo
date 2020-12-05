using AbpToExcel.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpToExcel.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpToExcelEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpToExcelApplicationContractsModule)
        )]
    public class AbpToExcelDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpToExcel.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpToExcelEntityFrameworkCoreModule)
        )]
    public class AbpToExcelEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpToExcelMigrationsDbContext>();
        }
    }
}

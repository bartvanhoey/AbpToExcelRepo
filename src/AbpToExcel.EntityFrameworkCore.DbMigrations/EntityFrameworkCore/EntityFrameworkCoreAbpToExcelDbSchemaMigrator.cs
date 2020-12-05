using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpToExcel.Data;
using Volo.Abp.DependencyInjection;

namespace AbpToExcel.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpToExcelDbSchemaMigrator
        : IAbpToExcelDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpToExcelDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpToExcelMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpToExcelMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
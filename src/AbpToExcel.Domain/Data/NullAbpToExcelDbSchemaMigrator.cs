using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpToExcel.Data;

/* This is used if database provider does't define
 * IAbpToExcelDbSchemaMigrator implementation.
 */
public class NullAbpToExcelDbSchemaMigrator : IAbpToExcelDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

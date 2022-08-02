using System.Threading.Tasks;

namespace AbpToExcel.Data;

public interface IAbpToExcelDbSchemaMigrator
{
    Task MigrateAsync();
}

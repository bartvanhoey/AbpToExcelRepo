using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpToExcel.EntityFrameworkCore
{
    public static class AbpToExcelDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpToExcel(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpToExcelConsts.DbTablePrefix + "YourEntities", AbpToExcelConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
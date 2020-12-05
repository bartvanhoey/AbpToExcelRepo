using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpToExcel
{
    [Dependency(ReplaceServices = true)]
    public class AbpToExcelBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpToExcel";
    }
}

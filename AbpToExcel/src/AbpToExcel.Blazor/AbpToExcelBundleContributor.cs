using Volo.Abp.Bundling;

namespace AbpToExcel.Blazor
{
    public class AbpToExcelBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css");
        }
    }
}

using Volo.Abp.Settings;

namespace AbpToExcel.Settings;

public class AbpToExcelSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpToExcelSettings.MySetting1));
    }
}

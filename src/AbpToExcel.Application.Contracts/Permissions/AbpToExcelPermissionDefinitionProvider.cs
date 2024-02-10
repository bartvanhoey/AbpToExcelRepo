using AbpToExcel.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpToExcel.Permissions;

public class AbpToExcelPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpToExcelPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpToExcelPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpToExcelResource>(name);
    }
}

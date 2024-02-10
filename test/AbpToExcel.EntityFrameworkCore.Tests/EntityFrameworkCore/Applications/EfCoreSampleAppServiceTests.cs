using AbpToExcel.Samples;
using Xunit;

namespace AbpToExcel.EntityFrameworkCore.Applications;

[Collection(AbpToExcelTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpToExcelEntityFrameworkCoreTestModule>
{

}

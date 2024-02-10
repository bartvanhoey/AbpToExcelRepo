using AbpToExcel.Samples;
using Xunit;

namespace AbpToExcel.EntityFrameworkCore.Domains;

[Collection(AbpToExcelTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpToExcelEntityFrameworkCoreTestModule>
{

}

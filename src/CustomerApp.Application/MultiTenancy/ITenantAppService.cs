using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CustomerApp.MultiTenancy.Dto;

namespace CustomerApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

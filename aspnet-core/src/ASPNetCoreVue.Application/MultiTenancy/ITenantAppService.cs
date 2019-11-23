using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ASPNetCoreVue.MultiTenancy.Dto;

namespace ASPNetCoreVue.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


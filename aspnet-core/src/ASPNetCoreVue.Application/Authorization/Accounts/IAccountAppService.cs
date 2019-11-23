using System.Threading.Tasks;
using Abp.Application.Services;
using ASPNetCoreVue.Authorization.Accounts.Dto;

namespace ASPNetCoreVue.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

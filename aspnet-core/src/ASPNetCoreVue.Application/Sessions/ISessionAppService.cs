using System.Threading.Tasks;
using Abp.Application.Services;
using ASPNetCoreVue.Sessions.Dto;

namespace ASPNetCoreVue.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

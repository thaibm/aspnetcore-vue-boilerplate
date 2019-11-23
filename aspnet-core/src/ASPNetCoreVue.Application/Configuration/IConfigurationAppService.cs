using System.Threading.Tasks;
using ASPNetCoreVue.Configuration.Dto;

namespace ASPNetCoreVue.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

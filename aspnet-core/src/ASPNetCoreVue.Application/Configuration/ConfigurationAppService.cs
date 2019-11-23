using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ASPNetCoreVue.Configuration.Dto;

namespace ASPNetCoreVue.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ASPNetCoreVueAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

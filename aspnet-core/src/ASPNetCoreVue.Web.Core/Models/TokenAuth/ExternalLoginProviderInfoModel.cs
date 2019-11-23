using Abp.AutoMapper;
using ASPNetCoreVue.Authentication.External;

namespace ASPNetCoreVue.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}

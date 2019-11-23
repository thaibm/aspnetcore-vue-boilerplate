using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ASPNetCoreVue.Configuration;

namespace ASPNetCoreVue.Web.Host.Startup
{
    [DependsOn(
       typeof(ASPNetCoreVueWebCoreModule))]
    public class ASPNetCoreVueWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ASPNetCoreVueWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ASPNetCoreVueWebHostModule).GetAssembly());
        }
    }
}

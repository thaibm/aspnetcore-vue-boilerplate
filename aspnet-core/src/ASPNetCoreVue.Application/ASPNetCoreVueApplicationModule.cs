using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ASPNetCoreVue.Authorization;

namespace ASPNetCoreVue
{
    [DependsOn(
        typeof(ASPNetCoreVueCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ASPNetCoreVueApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ASPNetCoreVueAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ASPNetCoreVueApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

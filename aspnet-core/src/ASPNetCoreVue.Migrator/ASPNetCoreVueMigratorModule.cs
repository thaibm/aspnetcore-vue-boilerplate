using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ASPNetCoreVue.Configuration;
using ASPNetCoreVue.EntityFrameworkCore;
using ASPNetCoreVue.Migrator.DependencyInjection;

namespace ASPNetCoreVue.Migrator
{
    [DependsOn(typeof(ASPNetCoreVueEntityFrameworkModule))]
    public class ASPNetCoreVueMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ASPNetCoreVueMigratorModule(ASPNetCoreVueEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ASPNetCoreVueMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ASPNetCoreVueConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ASPNetCoreVueMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}

using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebAfricaProject.Configuration;
using WebAfricaProject.EntityFrameworkCore;
using WebAfricaProject.ConsoleApp.DependencyInjection;

namespace WebAfricaProject.ConsoleApp
{
    [DependsOn(typeof(WebAfricaProjectEntityFrameworkModule))]
    public class WebAfricaProjectMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public WebAfricaProjectMigratorModule(WebAfricaProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = false;

            _appConfiguration = AppConfigurations.Get(
                typeof(WebAfricaProjectMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                WebAfricaProjectConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(WebAfricaProjectMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}

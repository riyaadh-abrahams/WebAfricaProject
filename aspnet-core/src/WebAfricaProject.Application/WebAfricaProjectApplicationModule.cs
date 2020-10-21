using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebAfricaProject.Authorization;

namespace WebAfricaProject
{
    [DependsOn(
        typeof(WebAfricaProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WebAfricaProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<WebAfricaProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(WebAfricaProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

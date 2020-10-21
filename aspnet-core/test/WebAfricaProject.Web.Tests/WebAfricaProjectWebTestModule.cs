using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebAfricaProject.EntityFrameworkCore;
using WebAfricaProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace WebAfricaProject.Web.Tests
{
    [DependsOn(
        typeof(WebAfricaProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class WebAfricaProjectWebTestModule : AbpModule
    {
        public WebAfricaProjectWebTestModule(WebAfricaProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebAfricaProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(WebAfricaProjectWebMvcModule).Assembly);
        }
    }
}
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebAfricaProject.Configuration;

namespace WebAfricaProject.Web.Host.Startup
{
    [DependsOn(
       typeof(WebAfricaProjectWebCoreModule))]
    public class WebAfricaProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public WebAfricaProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebAfricaProjectWebHostModule).GetAssembly());
        }
    }
}

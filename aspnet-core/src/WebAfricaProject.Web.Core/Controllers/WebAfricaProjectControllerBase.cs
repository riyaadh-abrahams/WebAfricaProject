using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace WebAfricaProject.Controllers
{
    public abstract class WebAfricaProjectControllerBase: AbpController
    {
        protected WebAfricaProjectControllerBase()
        {
            LocalizationSourceName = WebAfricaProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using WebAfricaProject.Configuration.Dto;

namespace WebAfricaProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : WebAfricaProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

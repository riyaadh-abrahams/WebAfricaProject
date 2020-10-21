using System.Threading.Tasks;
using WebAfricaProject.Configuration.Dto;

namespace WebAfricaProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

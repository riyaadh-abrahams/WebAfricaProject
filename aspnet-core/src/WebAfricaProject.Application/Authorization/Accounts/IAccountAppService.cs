using System.Threading.Tasks;
using Abp.Application.Services;
using WebAfricaProject.Authorization.Accounts.Dto;

namespace WebAfricaProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

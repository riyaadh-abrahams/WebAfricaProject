using System.Threading.Tasks;
using Abp.Application.Services;
using WebAfricaProject.Sessions.Dto;

namespace WebAfricaProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using WebAfricaProject.Roles.Dto;
using WebAfricaProject.Users.Dto;

namespace WebAfricaProject.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}

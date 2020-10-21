using Abp.Application.Services;
using WebAfricaProject.MultiTenancy.Dto;

namespace WebAfricaProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


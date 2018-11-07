using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CustomerApp.Roles.Dto;

namespace CustomerApp.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}

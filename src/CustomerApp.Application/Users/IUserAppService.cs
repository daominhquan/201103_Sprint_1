using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CustomerApp.Roles.Dto;
using CustomerApp.Users.Dto;

namespace CustomerApp.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
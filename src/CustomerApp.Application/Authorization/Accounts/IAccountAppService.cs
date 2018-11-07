using System.Threading.Tasks;
using Abp.Application.Services;
using CustomerApp.Authorization.Accounts.Dto;

namespace CustomerApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using CustomerApp.Sessions.Dto;

namespace CustomerApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

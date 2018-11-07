using System.Threading.Tasks;
using Abp.Application.Services;
using CustomerApp.Configuration.Dto;

namespace CustomerApp.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
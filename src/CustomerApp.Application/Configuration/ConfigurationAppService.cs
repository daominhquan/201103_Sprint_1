using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CustomerApp.Configuration.Dto;

namespace CustomerApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CustomerAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

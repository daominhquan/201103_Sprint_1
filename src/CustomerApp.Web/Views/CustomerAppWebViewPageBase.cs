using Abp.Web.Mvc.Views;

namespace CustomerApp.Web.Views
{
    public abstract class CustomerAppWebViewPageBase : CustomerAppWebViewPageBase<dynamic>
    {

    }

    public abstract class CustomerAppWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected CustomerAppWebViewPageBase()
        {
            LocalizationSourceName = CustomerAppConsts.LocalizationSourceName;
        }
    }
}
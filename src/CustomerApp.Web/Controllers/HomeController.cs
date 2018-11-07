using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CustomerApp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : CustomerAppControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}
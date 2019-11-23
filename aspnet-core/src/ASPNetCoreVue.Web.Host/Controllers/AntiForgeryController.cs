using Microsoft.AspNetCore.Antiforgery;
using ASPNetCoreVue.Controllers;

namespace ASPNetCoreVue.Web.Host.Controllers
{
    public class AntiForgeryController : ASPNetCoreVueControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}

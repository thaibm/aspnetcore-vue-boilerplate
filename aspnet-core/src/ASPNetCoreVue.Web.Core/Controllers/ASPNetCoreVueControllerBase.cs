using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ASPNetCoreVue.Controllers
{
    public abstract class ASPNetCoreVueControllerBase: AbpController
    {
        protected ASPNetCoreVueControllerBase()
        {
            LocalizationSourceName = ASPNetCoreVueConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

using Abp.Authorization;
using ASPNetCoreVue.Authorization.Roles;
using ASPNetCoreVue.Authorization.Users;

namespace ASPNetCoreVue.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

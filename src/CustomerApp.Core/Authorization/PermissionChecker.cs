using Abp.Authorization;
using CustomerApp.Authorization.Roles;
using CustomerApp.Authorization.Users;

namespace CustomerApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

using Abp.Authorization;
using WebAfricaProject.Authorization.Roles;
using WebAfricaProject.Authorization.Users;

namespace WebAfricaProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

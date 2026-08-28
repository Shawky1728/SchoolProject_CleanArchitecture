using Microsoft.AspNetCore.Authorization;
using SchoolProject.Data.Authorization;

namespace SchoolProject.Core.Authorization
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var user = context.User.Identity;

            if (user is null || !user.IsAuthenticated)
            {
                return;
            }

            var userPermissions = context.User.Claims.Any(c => c.Value == requirement.Permission && c.Type == Permissions.Type);

            if (!userPermissions)
            {
                return;
            }

            context.Succeed(requirement);
            return;
        }
    }
}

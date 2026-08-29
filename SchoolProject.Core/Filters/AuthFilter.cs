using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.AuthentecationService.Interface;

namespace SchoolProject.Core.Filters
{
    public class AuthFilter : IAsyncActionFilter
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<User> _userManager;
        public AuthFilter(ICurrentUserService currentUserService, UserManager<User> userManager)
        {
            _currentUserService = currentUserService;
            _userManager = userManager;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == false)
            {
                context.HttpContext.Response.StatusCode = 401;
                return;
            }

            var user = await _currentUserService.GetUserAsync();
            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null || !roles.Any())
            {
                context.HttpContext.Response.StatusCode = 403;
                return;
            }

            var result = await next();

            // After action
        }
    }
}

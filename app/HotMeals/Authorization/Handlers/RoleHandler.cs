using HotMeals.Authorization.Requirements;
using HotMeals.Data.School;
using HotMeals.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace HotMeals.Authorization.Handlers
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        private readonly SchoolContext _schoolContext;

        public RoleHandler(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var userName = context.User.Identity?.Name;
            if (userName == null)
                return;
            var user = await _schoolContext.Users.Include(u => u.Staff).FirstOrDefaultAsync(u => u.UserName == userName);
            if (user != null && user.Staff != null && user.Staff.Role == RoleEnum.teaching.ToString())
            {
                context.Succeed(requirement);
            }
        }
    }
}

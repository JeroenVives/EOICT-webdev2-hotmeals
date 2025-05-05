using HotMeals.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace HotMeals.Authorization.Requirements
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public RoleRequirement(RoleEnum role)
        {
            Role = role;
        }

        public RoleEnum Role { get; }
    }
}

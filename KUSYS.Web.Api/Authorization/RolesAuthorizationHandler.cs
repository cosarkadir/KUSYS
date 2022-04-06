using KUSYS.Core.Contracts;
using KUSYS.Core.Service;
using KUSYS.Web.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace KUSYS.Web.Api.Authorization
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        IUserService _userService;
        public RolesAuthorizationHandler(IUserService userService)
        {
            _userService = userService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;

            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var validRole = false;
            if (requirement.AllowedRoles == null ||
                requirement.AllowedRoles.Any() == false
                || requirement.AllowedRoles.Contains(Roles.All))
            {
                validRole = true;
            }
            else
            {
                var claims = context.User.Claims;
                var userName = claims.FirstOrDefault(c => c.Type == "UserName").Value;
                var password = claims.FirstOrDefault(c => c.Type == "Password").Value;
                var roles = requirement.AllowedRoles.ToList();

                ServiceResponse<bool> serviceResponse = _userService.Authenticate(userName, password, roles[0]).Result;
                validRole = serviceResponse.IsSuccessfull;
            }

            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}

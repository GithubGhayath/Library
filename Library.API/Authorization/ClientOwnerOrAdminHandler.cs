using Library.Application.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Library.API.Authorization
{
    public class ClientOwnerOrAdminHandler : AuthorizationHandler<ClientOwnerOrAdminRequirement, int>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClientOwnerOrAdminRequirement requirement, int clientId)
        {
            
            // Admin override
            if (context.User.IsInRole(Roles.Admin))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            // Ownership check
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (int.TryParse(userId, out int authenticatedStudentId) &&
                authenticatedStudentId == clientId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

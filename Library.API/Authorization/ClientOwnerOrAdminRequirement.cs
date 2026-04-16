using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Library.API.Authorization
{
    public class ClientOwnerOrAdminRequirement : IAuthorizationRequirement
    {
    }
}

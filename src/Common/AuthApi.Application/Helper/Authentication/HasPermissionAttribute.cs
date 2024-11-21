using AuthApi.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace AuthApi.Application.Helper.Authentication;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permission permission) : base(policy: permission.ToString())
    {
    }
}

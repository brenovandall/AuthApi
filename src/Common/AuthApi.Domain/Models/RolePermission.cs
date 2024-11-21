using System;

namespace AuthApi.Domain.Models;

public class RolePermission
{
    public int RoleId { get; set; }
    public int PermissionId { get; set; }
}

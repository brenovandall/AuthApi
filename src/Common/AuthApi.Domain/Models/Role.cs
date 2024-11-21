using AuthApi.Domain.Shared;

namespace AuthApi.Domain.Models;

public sealed class Role : Enumeration<Role>
{
    public static readonly Role Registered = new(1, "Registered");

    public Role(int id, string name) : base(id, name)
    {
    }
    
    public ICollection<RolePermission> RolePermissions { get; set; } = [];
    public IList<MemberRoles> MemberRoles { get; set; } = [];
}

using AuthApi.Application.Data;
using AuthApi.Domain.Models;
using AuthApi.Domain.ValueObjects;

namespace AuthApi.Application.Abstractions;

public class PermissionService (ICommandDbContext _context) : IPermissionService
{
    public async Task<HashSet<string>> GetPermissionsAsync(MemberId memberId)
    {
        var upperId = MemberId.Of(memberId.Value).Value.ToString().ToUpper();

        ICollection<Role> roles = _context.Members
            .Where(member => member.Id == MemberId.Of(Guid.Parse(upperId)))
            .Join(
                _context.MemberRoles, 
                member => member.Id,
                mr => mr.MemberId,
                (member, mr) => mr
            )
            .Join(
                _context.Roles,
                mr => mr.RoleId,
                r => r.Id,
                (mr, r) => r
            )
            .ToList();
 
        return roles
            .SelectMany(r => r.RolePermissions)
            .Join(
                _context.Permissions,
                r => r.PermissionId,
                p => p.Id,
                (r, p) => p.Name
            )
            .ToHashSet();
    }
}

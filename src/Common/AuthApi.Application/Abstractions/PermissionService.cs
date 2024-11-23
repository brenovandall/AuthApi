using AuthApi.Application.Data;
using AuthApi.Domain.Models;
using AuthApi.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Application.Abstractions;

public class PermissionService (ICommandDbContext _context) : IPermissionService
{
    public async Task<HashSet<string>> GetPermissionsAsync(MemberId memberId)
    {
        var t = _context.Members.ToList();
        var tt = _context.Roles.ToList();

        ICollection<Role> roles = _context.Members
            .Where(member => member.Id == memberId)
            .SelectMany(member => member.Roles)
            .Include(x => x.Permissions)
            .Include(x => x.Members)
            .ToList();

        HashSet<string> permissions = roles
            .Select(x => x)
            .SelectMany(x => x.Permissions)
            .Select(x => x.Name)
            .ToHashSet();

        return permissions;
    }
}

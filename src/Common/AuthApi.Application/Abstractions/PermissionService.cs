using AuthApi.Application.Data;
using AuthApi.Domain.Models;
using AuthApi.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Application.Abstractions;

public class PermissionService (ICommandDbContext _context) : IPermissionService
{
    public async Task<HashSet<string>> GetPermissionsAsync(MemberId memberId)
    {
        //var upperId = MemberId.Of(memberId.Value).Value.ToString().ToUpper();

        //ICollection<Role> roles = _context.Members
        //    .Include(x => x)
        //    .Where(member => member.Id == MemberId.Of(Guid.Parse(upperId)))
        //    .ToList();

        //return roles
        //    .SelectMany(x => x.Permissions)
        //    .Select(x => x.Name)
        //    .ToHashSet();

        return new HashSet<string> { };
    }
}

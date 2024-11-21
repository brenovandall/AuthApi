using Microsoft.EntityFrameworkCore;

namespace AuthApi.Application.Data;

public interface IReadDbContext
{
    DbSet<Domain.Models.Member> Members { get; }
    DbSet<Domain.Models.Role> Roles { get; }
    DbSet<Domain.Models.Permission> Permissions { get; }
    DbSet<Domain.Models.MemberRoles> MemberRoles { get; }
    DbSet<Domain.Models.RolePermission> RolePermissions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

using Microsoft.EntityFrameworkCore;

namespace AuthApi.Application.Data;

public interface ICommandDbContext
{
    DbSet<Domain.Models.Member> Members { get; }
    DbSet<Domain.Models.Role> Roles { get; }
    DbSet<Domain.Models.Permission> Permissions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

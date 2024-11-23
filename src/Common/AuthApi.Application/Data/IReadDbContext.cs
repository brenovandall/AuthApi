using Microsoft.EntityFrameworkCore;

namespace AuthApi.Application.Data;

public interface IReadDbContext
{
    DbSet<Domain.Models.Member> Members { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

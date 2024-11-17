using AuthApi.Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthApi.Infrastructure.ReadData;

public class ReadDbContext : DbContext, IReadDbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Models.Member> Members => Set<Domain.Models.Member>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

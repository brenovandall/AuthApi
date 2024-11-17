using AuthApi.Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthApi.Infrastructure.CommandData;

public class CommandDbContext : DbContext, ICommandDbContext
{
    public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Models.Member> Members => Set<Domain.Models.Member>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

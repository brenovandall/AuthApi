using AuthApi.Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthApi.Infrastructure.CommandData;

public class CommandDbContext : DbContext, ICommandDbContext
{
    public CommandDbContext()
    {
        
    }
    public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Models.Member> Members => Set<Domain.Models.Member>();
    public DbSet<Domain.Models.Role> Roles => Set<Domain.Models.Role>();
    public DbSet<Domain.Models.Permission> Permissions => Set<Domain.Models.Permission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.UseCollation("NOCASE");

        base.OnModelCreating(modelBuilder);
    }
}

using AuthApi.Application.Data;
using AuthApi.Domain.Enums;
using AuthApi.Domain.Models;
using AuthApi.Domain.ValueObjects;
using AuthApi.Infrastructure.Consts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthApi.Infrastructure.ReadData;

public class ReadDbContext : DbContext, IReadDbContext
{
    public ReadDbContext()
    {
        
    }
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Models.Member> Members => Set<Domain.Models.Member>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Member>().ToTable(TableNames.Members);

        builder.Entity<Member>().HasKey(x => x.Id);

        builder.Entity<Member>().Property(x => x.Id).HasConversion(
            id => id.Value,
            dbId => MemberId.Of(dbId));

        builder.Entity<Member>().Property(x => x.Email).HasConversion(
            email => email.Value,
            dbEmail => Email.Of(dbEmail));

        builder.Entity<Member>().Property(x => x.FirstName).HasConversion(
            firstName => firstName.Value,
            dbFirstName => FirstName.Of(dbFirstName));

        builder.Entity<Member>().Property(x => x.LastName).HasConversion(
           lastName => lastName.Value,
           dbLastName => LastName.Of(dbLastName));

        builder.Entity<Member>().Property(x => x.Plan)
           .HasDefaultValue(Plan.None)
           .HasConversion(s => s.ToString(), dbPlan => (Plan)Enum.Parse(typeof(Plan), dbPlan));

        base.OnModelCreating(builder);
    }
}

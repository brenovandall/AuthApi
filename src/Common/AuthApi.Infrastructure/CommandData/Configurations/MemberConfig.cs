
using System.Security.Cryptography.X509Certificates;
using AuthApi.Domain.Enums;
using AuthApi.Domain.Models;
using AuthApi.Domain.ValueObjects;
using AuthApi.Infrastructure.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApi.Infrastructure.CommandData.Configurations;

public class MemberConfig : IEntityTypeConfiguration<Domain.Models.Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable(TableNames.Members);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
            id => id.Value,
            dbId => MemberId.Of(dbId));

        builder.Property(x => x.Email).HasConversion(
            email => email.Value,
            dbEmail => Email.Of(dbEmail));

        builder.Property(x => x.FirstName).HasConversion(
            firstName => firstName.Value,
            dbFirstName => FirstName.Of(dbFirstName));

        builder.Property(x => x.LastName).HasConversion(
           lastName => lastName.Value,
           dbLastName => LastName.Of(dbLastName));

        builder.Property(x => x.Plan)
           .HasDefaultValue(Plan.None) 
           .HasConversion(s => s.ToString(), dbPlan => (Plan)Enum.Parse(typeof(Plan), dbPlan));

        builder.HasMany(x => x.Roles)
            .WithMany()
            .UsingEntity<MemberRoles>();
    }
}

using AuthApi.Domain.Models;
using AuthApi.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApi.Infrastructure.CommandData.Configurations;

public class MemberRolesConfig : IEntityTypeConfiguration<MemberRoles>
{
    public void Configure(EntityTypeBuilder<MemberRoles> builder)
    {
        builder.HasKey(x => new { x.MemberId, x.RoleId });

        builder.Property(x => x.MemberId)
            .HasConversion(
                id => id.Value,
                dbId => MemberId.Of(dbId));

        builder.HasOne(x => x.Member)
            .WithMany()
            .HasForeignKey(x => x.MemberId);

        builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId);
    }
}

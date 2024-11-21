using System;
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
            dbId => MemberId.Of(dbId)
        );

        builder.HasOne<Member>()
            .WithMany(m => m.MemberRoles)
            .HasForeignKey(x => x.MemberId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Role>()
            .WithMany(r => r.MemberRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

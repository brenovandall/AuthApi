using AuthApi.Domain.Models;
using AuthApi.Domain.ValueObjects;
using AuthApi.Infrastructure.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApi.Infrastructure.CommandData.Configurations;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNames.Roles);

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Members)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                TableNames.MemberRoles,
                j => j.HasOne<Member>().WithMany().HasForeignKey("MemberId").OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Cascade));

        builder.HasMany(x => x.Permissions)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                TableNames.RolePermissions,
                j => j.HasOne<Permission>().WithMany().HasForeignKey("PermissionId").OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Cascade));

        builder.HasData(Role.GetValues());
    }
}

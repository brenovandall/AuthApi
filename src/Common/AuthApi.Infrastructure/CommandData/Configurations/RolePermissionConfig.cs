using AuthApi.Domain.Enums;
using AuthApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApi.Infrastructure.CommandData.Configurations;

public class RolePermissionConfig : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(x => new { x.RoleId, x.PermissionId });

        // builder.HasData(
        //     Create(Role.Registered, Domain.Enums.Permission.ReadMember),
        //     Create(Role.Registered, Domain.Enums.Permission.UpdateMember)
        // );

        builder.HasOne<Domain.Models.Permission>()
            .WithMany(m => m.RolePermissions)
            .HasForeignKey(x => x.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Domain.Models.Role>()
            .WithMany(m => m.RolePermissions)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static RolePermission Create(Role role, Domain.Enums.Permission permission)
    {
        return new RolePermission
        {
            RoleId = role.Id,
            PermissionId = (int)permission
        };
    }
}

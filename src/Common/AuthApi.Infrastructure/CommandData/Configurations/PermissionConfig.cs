using AuthApi.Domain.Models;
using AuthApi.Infrastructure.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApi.Infrastructure.CommandData.Configurations;

public class PermissionConfig : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(TableNames.Permissions);

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Roles)
            .WithMany()
            .UsingEntity<RolePermission>();

        IEnumerable<Permission> permissions = Enum.GetValues<Domain.Enums.Permission>()
            .Select(x => new Permission
            {
                Id = (int)x,
                Name = x.ToString(),
            });

        builder.HasData(permissions);
    }
}

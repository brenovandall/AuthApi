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
            .UsingEntity<MemberRoles>();

        builder.HasMany(x => x.Permissions)
            .WithMany()
            .UsingEntity<MemberRoles>();

        builder.HasData(Role.GetValues());
    }
}

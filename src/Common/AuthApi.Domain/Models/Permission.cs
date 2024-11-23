namespace AuthApi.Domain.Models;

public class Permission
{
    public int Id { get; init;}
    public string Name { get; init; } = string.Empty;
    public ICollection<Role> Roles { get; set; } = [];
}

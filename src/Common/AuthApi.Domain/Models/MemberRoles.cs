using System;
using AuthApi.Domain.ValueObjects;

namespace AuthApi.Domain.Models;

public class MemberRoles
{
    public MemberId MemberId { get; set; }
    public int RoleId { get; set; }
}

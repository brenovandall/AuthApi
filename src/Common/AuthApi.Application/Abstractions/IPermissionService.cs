using System;
using AuthApi.Domain.ValueObjects;

namespace AuthApi.Application.Abstractions;

public interface IPermissionService
{
    Task<HashSet<string>> GetPermissionsAsync(MemberId memberId);
}

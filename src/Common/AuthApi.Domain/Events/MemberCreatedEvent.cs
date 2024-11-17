using AuthApi.Domain.Abstractions;
using AuthApi.Domain.Models;

namespace AuthApi.Domain.Events;

public record MemberCreatedEvent(Member member) : IDominEvent;

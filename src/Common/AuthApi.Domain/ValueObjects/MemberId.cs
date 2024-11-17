namespace AuthApi.Domain.ValueObjects;

public record MemberId
{
    public Guid Value { get; }
    private MemberId(Guid value) => Value = value;

    public static MemberId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return new MemberId(value);
    }
}

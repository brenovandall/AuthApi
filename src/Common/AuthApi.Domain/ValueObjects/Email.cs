namespace AuthApi.Domain.ValueObjects;

public record Email
{
    public string Value { get; }
    private Email(string value) => Value = value;

    public static Email Of(string value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return new Email(value);
    }
}

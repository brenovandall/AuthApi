namespace AuthApi.Domain.ValueObjects;

public record LastName
{
    public string Value { get; }
    private LastName(string value) => Value = value;

    public static LastName Of(string value) => new LastName(value);
}

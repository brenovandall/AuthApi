namespace AuthApi.Domain.ValueObjects;

public record FirstName
{
    public string Value { get; }
    private FirstName(string value) => Value = value;

    public static FirstName Of(string value) => new FirstName(value);
}

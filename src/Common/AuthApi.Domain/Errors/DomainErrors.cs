namespace AuthApi.Domain.Errors;

public static class DomainErrors
{
    public static class Member
    {
        public static readonly string InvalidCredentials = new(
            "The provided credentials are invalid"
        );
    }
}

namespace Sonawis.Shared.Domain.Errors;
public static class FirstNameErrors
{
    public static readonly Error Empty = new(
            "FirstName.Empty",
            "First name is empty");

    public static readonly Error TooLong = new(
        "LastName.TooLong",
        "FirstName name is too long");
}

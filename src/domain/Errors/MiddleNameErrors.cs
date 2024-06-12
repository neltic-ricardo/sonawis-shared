namespace Sonawis.Shared.Domain.Errors;
public static class MiddleNameErrors
{
    public static readonly Error Empty = new(
            "MiddleName.Empty",
            "First name is empty");

    public static readonly Error TooLong = new(
        "MiddleName.TooLong",
        "MiddleName name is too long");
}

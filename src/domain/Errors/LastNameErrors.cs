namespace Sonawis.Shared.Domain.Errors;

public static class LastNameErrors
{
    public static readonly Error Empty = new(
        "LastName.Empty",
        "Last name is empty");

    public static readonly Error TooLong = new(
        "LastName.TooLong",
        "Last name is too long");
}

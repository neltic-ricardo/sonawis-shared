namespace Sonawis.Shared.Domain.Errors;
public class StringErrors
{
    public static readonly Error Empty = new(
            "String.Empty",
            "Value must be defined");
}

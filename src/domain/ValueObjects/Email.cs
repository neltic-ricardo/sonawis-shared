using Sonawis.Shared.Domain.Errors;
using Sonawis.Shared.Domain.Validator;

namespace Sonawis.Shared.Domain.ValueObjects;


public sealed class Email : ValueObject
{
    public const int MaxLength = 255;

    private Email(string value) => Value = value;

    private Email()
    {
    }

    public string Value { get; private set; } = string.Empty;

    public static Result<Email> Create(string email) =>
        Result.Create(email)
            .Ensure(
                e => !string.IsNullOrWhiteSpace(e),
                EmailErrors.Empty)
            .Ensure(
                e => e.Length <= MaxLength,
                EmailErrors.TooLong)
            .Ensure(
                e => e.Split('@').Length == 2,
                EmailErrors.InvalidFormat)
            .Map(e => new Email(e));

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}

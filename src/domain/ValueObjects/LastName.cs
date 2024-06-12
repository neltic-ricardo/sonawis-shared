using Sonawis.Shared.Domain.Errors;
using Sonawis.Shared.Domain.Validator;

namespace Sonawis.Shared.Domain.ValueObjects;

public sealed class LastName : ValueObject
{
    public const int MaxLength = 50;

    private LastName(string value) 
        => Value = value;
    

    private LastName()
    {
    }

    public string Value { get; private set; } = string.Empty;

    public static Result<LastName> Create(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<LastName>(LastNameErrors.Empty);
        }

        if (lastName.Length > MaxLength)
        {
            return Result.Failure<LastName>(LastNameErrors.TooLong);
        }

        return new LastName(lastName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}


using Sonawis.Shared.Domain.Errors;
using Sonawis.Shared.Domain.Validator;

namespace Sonawis.Shared.Domain.ValueObjects;
public class MiddleName : ValueObject
{
    public const int MaxLength = 50;

    public string Value { get; private set; } = string.Empty;

    private MiddleName(string value) 
        => Value = value;
    

    private MiddleName()
    {
    }

    public static Result<MiddleName> Create(string middleName)
    {
        if (string.IsNullOrWhiteSpace(middleName))
            return Result.Failure<MiddleName>(MiddleNameErrors.Empty);

        if (middleName.Length > MaxLength)
            return Result.Failure<MiddleName>(MiddleNameErrors.TooLong);

        return new MiddleName(middleName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}


using Sonawis.Shared.Domain.Errors;
using Sonawis.Shared.Domain.Validator;

namespace Sonawis.Shared.Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 50;

    private FirstName(string value)
        => Value = value;
    

    private FirstName()
    {
    }

    public string Value { get; private set; } = string.Empty;

    public static Result<FirstName> Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))        
            return Result.Failure<FirstName>(FirstNameErrors.Empty);
        

        if (firstName.Length > MaxLength)        
            return Result.Failure<FirstName>(FirstNameErrors.TooLong);
        

        return new FirstName(firstName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}


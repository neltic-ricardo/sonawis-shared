using Sonawis.Shared.Domain.Errors;
using Sonawis.Shared.Domain.Validator;

namespace Sonawis.Shared.Domain.ValueObjects;

public class StringValueObject : ValueObject
{
    public string Value { get; private set; } = string.Empty;

    private StringValueObject(string value)
        => Value = value;


    protected StringValueObject()
    {

    }

    public static Result<StringValueObject> Create(string value)
        => string.IsNullOrWhiteSpace(value)
            ? Result.Failure<StringValueObject>(StringErrors.Empty)
            : Result.Success<StringValueObject>(new(value));


    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}


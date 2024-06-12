using Sonawis.Shared.Domain.Errors;

namespace Sonawis.Shared.Domain.Validator;
public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation problem occurred.");

    Error[] Errors { get; }
}

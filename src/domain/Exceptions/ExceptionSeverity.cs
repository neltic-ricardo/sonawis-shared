namespace Sonawis.Shared.Domain.Exceptions;
/// <summary>
/// Indica el nivel se gravedad de una excepción.
/// </summary>
public enum ExceptionSeverity : int
{
    /// <summary>
    /// Indica que no se le asignó ninguna gravedad a la excepción.
    /// </summary>
    None = -1,

    /// <summary>
    /// Indica que la excepción es sólo un mensaje para el usuario.
    /// </summary>
    Message = 0,

    /// <summary>
    /// Indica que la excepción tiene un tipo de gravedad baja.
    /// </summary>
    Low = 1,

    /// <summary>
    /// Indica que la excepción tiene un tipo de gravedad media.
    /// </summary>
    Middle = 2,

    /// <summary>
    /// Indica que la excepción tiene un tipo de gravedad alta.
    /// </summary>
    High = 3,

    /// <summary>
    /// Indica que la excepción tiene un tipo de gravedad crítica.
    /// </summary>
    Critical = 4
}

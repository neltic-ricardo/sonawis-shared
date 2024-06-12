using System.Linq.Expressions;

namespace Sonawis.Shared.Domain.Specification;
/// <summary>
/// A logic AND Specification
/// </summary>
/// <typeparam name="T">Type of entity that check this specification</typeparam>
public class AndSpecification<T> : CompositeSpecification<T> where T : class
{
    #region Members

    private readonly ISpecification<T> _rightSideSpecification;
    private readonly ISpecification<T> _leftSideSpecification;

    #endregion

    #region Public Constructor

    /// <summary>
    /// Default constructor for AndSpecification
    /// </summary>
    /// <param name="leftSide">Left side specification</param>
    /// <param name="rightSide">Right side specification</param>
    public AndSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
    {
        if (leftSide is null)
            throw new ArgumentNullException("leftSide");

        if (rightSide is null)
            throw new ArgumentNullException("rightSide");

        _leftSideSpecification = leftSide;
        _rightSideSpecification = rightSide;
    }

    #endregion

    #region Composite Specification overrides

    /// <summary>
    /// Left side specification
    /// </summary>
    public override ISpecification<T> LeftSideSpecification
    {
        get => _leftSideSpecification; 
    }

    /// <summary>
    /// Right side specification
    /// </summary>
    public override ISpecification<T> RightSideSpecification
    {
        get => _rightSideSpecification; 
    }

    /// <summary>
    /// <see cref="ISpecification{T}"/>
    /// </summary>
    /// <returns><see cref="ISpecification{T}"/></returns>
    public override Expression<Func<T, bool>> SatisfiedBy()
    {
        var left = _leftSideSpecification.SatisfiedBy();
        var right = _rightSideSpecification.SatisfiedBy();

        return left.And(right);
    }

    #endregion
}

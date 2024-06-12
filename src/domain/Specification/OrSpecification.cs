using System.Linq.Expressions;

namespace Sonawis.Shared.Domain.Specification;
/// <summary>
/// A Logic OR Specification
/// </summary>
/// <typeparam name="T">Type of entity that check this specification</typeparam>
public class OrSpecification<T>
     : CompositeSpecification<T>
     where T : class
{
    #region Members

    private readonly ISpecification<T> _RightSideSpecification;
    private readonly ISpecification<T> _LeftSideSpecification; 

    #endregion

    #region Public Constructor

    /// <summary>
    /// Default constructor for AndSpecification
    /// </summary>
    /// <param name="leftSide">Left side specification</param>
    /// <param name="rightSide">Right side specification</param>
    public OrSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
    {
        if (leftSide is null)
            throw new ArgumentNullException("leftSide");

        if (rightSide is null)
            throw new ArgumentNullException("rightSide");

        _LeftSideSpecification = leftSide;
        _RightSideSpecification = rightSide;
    }

    #endregion

    #region Composite Specification overrides

    /// <summary>
    /// Left side specification
    /// </summary>
    public override ISpecification<T> LeftSideSpecification
    {
        get { return _LeftSideSpecification; }
    }

    /// <summary>
    /// Righ side specification
    /// </summary>
    public override ISpecification<T> RightSideSpecification
    {
        get { return _RightSideSpecification; }
    }
    /// <summary>
    /// <see cref="Domain.Core.Specification.ISpecification{T}"/>
    /// </summary>
    /// <returns><see cref="ISpecification{T}"/></returns>
    public override Expression<Func<T, bool>> SatisfiedBy()
    {
        var left = _LeftSideSpecification.SatisfiedBy();
        var right = _RightSideSpecification.SatisfiedBy();

        return left.Or(right);

    }

    #endregion
}

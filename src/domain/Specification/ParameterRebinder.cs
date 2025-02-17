﻿using System.Linq.Expressions;

namespace Sonawis.Shared.Domain.Specification;
/// <summary>
/// Helper for rebinder parameters without use Invoke method in expressions 
/// ( this methods is not supported in all linq query providers, 
/// for example in Linq2Entities is not supported)
/// </summary>
public class ParameterRebinder : ExpressionVisitor
{
    private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

    /// <summary>
    /// Default construcotr
    /// </summary>
    /// <param name="map">Map specification</param>
    public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    {
        _map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    }
    /// <summary>
    /// Replate parameters in expression with a Map information
    /// </summary>
    /// <param name="map">Map information</param>
    /// <param name="exp">Expression to replace parameters</param>
    /// <returns>Expression with parameters replaced</returns>
    public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
    {
        return new ParameterRebinder(map).Visit(exp);
    }
    /// <summary>
    /// Visit pattern method
    /// </summary>
    /// <param name="p">A Parameter expression</param>
    /// <returns>New visited expression</returns>
    protected override Expression VisitParameter(ParameterExpression p)
    {
        ParameterExpression replacement;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        if (_map.TryGetValue(p, out replacement))
        {
            p = replacement;
        }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        return base.VisitParameter(p);
    }

}


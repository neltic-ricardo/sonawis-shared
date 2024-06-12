using Microsoft.EntityFrameworkCore;

using Sonawis.Shared.Domain;

namespace Sonawis.Shared.Persistence;

/// <summary>
/// The UnitOfWork contract for EF implementation
/// <remarks>
/// This contract extend IUnitOfWork for use with EF code
/// </remarks>
/// </summary>
public interface IQueryableContext : IContext
{
    /// <summary>
    /// Returns a IDbSet instance for access to entities of the given type in the context, 
    /// the ObjectStateManager, and the underlying store. 
    /// </summary>
    /// <typeparam name="TValueObject"></typeparam>
    /// <returns></returns>
    DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

    void SetUnchanged<TEntity>(TEntity item) where TEntity : class;

    void SetModified<TEntity>(TEntity item) where TEntity : class;

    void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
}

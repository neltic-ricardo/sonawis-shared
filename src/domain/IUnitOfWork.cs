namespace Sonawis.Shared.Domain;
/// <summary>
/// Contract for ‘UnitOfWork pattern’. For more
/// related info see http://martinfowler.com/eaaCatalog/unitOfWork.html or
/// http://msdn.microsoft.com/en-us/magazine/dd882510.aspx
/// In this solution, the Unit Of Work is implemented using the out-of-box 
/// Entity Framework Context (EF 4.1 DbContext) persistence engine. But in order to
/// comply the PI (Persistence Ignorant) principle in our Domain, we implement this interface/contract. 
/// This interface/contract should be complied by any UoW implementation to be used with this Domain.
/// </summary>
public interface IUnitOfWork    
{
    /// <summary>
    /// Commit all changes made in a container.
    /// </summary>
    ///<remarks>
    /// If the entity have fixed properties and any optimistic concurrency problem exists,  
    /// then an exception is thrown
    ///</remarks>
    Task CommitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Commit all changes made in  a container.
    /// </summary>
    ///<remarks>
    /// If the entity have fixed properties and any optimistic concurrency problem exists,
    /// then 'client changes' are refreshed - Client wins
    ///</remarks>
    Task CommitAndRefreshChangesAsync(CancellationToken cancellationToken = default);


    /// <summary>
    /// Rollback tracked changes. See references of UnitOfWork pattern
    /// </summary>
    Task RollbackChangesAsync(CancellationToken cancellationToken = default);    
}

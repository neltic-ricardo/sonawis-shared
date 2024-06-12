using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

using Sonawis.Shared.Domain.Entities;

namespace Sonawis.Shared.Infrastructure.Persistence.QuerySpecs;
public static class QuerySpecExtension
{
    public static async Task<IQueryable<TEntity>> ApplyAsync<TEntity>(this IQueryable<TEntity> query, QuerySpec querySpec) where TEntity : Entity
    {

        var total = await query.CountAsync();


        // Todo: We need to parse the query string to prevent SQL Injection.  
        if (!string.IsNullOrEmpty(querySpec.Filter))
        {
            query = query.Where(querySpec.Filter);
        }



        query = !string.IsNullOrEmpty(querySpec.OrderBy) ? query.OrderBy(querySpec.OrderBy) : query.OrderBy(e => e.Id);

        // For now if query spec PageSize is -1 that means all records.
        if (querySpec.PageSize > 0)
        {
            query = query.Skip(querySpec.PageNumber * querySpec.PageSize)
                         .Take(querySpec.PageSize);
        }

        if (!string.IsNullOrEmpty(querySpec.Select))
            query = query.Select<TEntity>($"new({querySpec.Select})");



        return query;
    }
}

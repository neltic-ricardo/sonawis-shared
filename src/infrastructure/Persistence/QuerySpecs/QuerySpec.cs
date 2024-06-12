using Microsoft.AspNetCore.Http;

namespace Sonawis.Shared.Infrastructure.Persistence.QuerySpecs;

public class QuerySpec
{
    /// <summary>
    /// Indicates the maximum number of items that should be returned in the results (defaults to 25).
    /// </summary>
    public int PageSize { get; set; } = 25;
    
    /// <summary>
    /// Indicates how many pages should be skipped before returning results.
    /// </summary>
    public int PageNumber { get; set; } = 0;

    /// <summary>
    /// Indicates how many rows should be skipped before returning results.
    /// </summary>
    public int? SkipCount { get; set; }

    /// <summary>
    /// Indicate the filter to apply to the resource.
    /// </summary>
    ///<example>Filter="FirstName.Contains('jo') and City == 'London' and Orders.Count >= 10"</example>
    public string? Filter { get; set; } = "1 = 1";

    /// <summary>
    /// Indicates the projection properties that will be selected in the return resource.
    /// </summary>
    /// <example>Select="Id, FirstName & " " & LastName as Name"</example>
    public string Select { get; set; }

    /// <summary>
    /// The search that should be added to all columns
    /// </summary>
    public string? Search { get; set; }

    /// <summary>
    /// Indicate the base filter to apply to the resource. Is the 
    /// base filter that indicates what the total should be when 
    /// paging.
    /// </summary>
    ///<example>Filter="FirstName.Contains('jo') and City == 'London' and Orders.Count >= 10"</example>
    public string BaseFilter { get; set; }

    /// <summary>
    /// Indicates the orderby properties that will be applied to the resulting resource collection.
    /// </summary>
    /// <example>OrderBy="LastName desc, FirstName desc, Id"</example>
    public string OrderBy { get; set; } = "Id";

    /// <summary>
    /// Indicates whether the call is a paging call.
    /// </summary>
    /// <example>Paging=true</example>
    public bool Paging { get; set; } = false;

    /// <summary>
    /// Indicate the filter to apply to the outter query.
    /// Syntax [field 1];[operand 1]:[value 1],[field n];[operand n]:[value n]
    /// </summary>
    ///<example>Filter="">
    public string OuterFilter { get; set; } = "";

    public QuerySpec(string? select, string? search, string? filter, string orderBy, int pageSize, int pageNumber, int skipCount, bool paging)
    {
        Select = select;
        Search = search;
        Filter = filter;
        OrderBy = orderBy;
        PageSize = pageSize;
        PageNumber = pageNumber;
        SkipCount = skipCount;
        Paging = paging;
    }

    public static QuerySpec Create(string? select, string? search, string? filter, string orderBy, int pageSize, int pageNumber, int skipCount, bool paging)
        => new QuerySpec(select, search, filter, orderBy, pageSize, pageNumber, skipCount, paging);

    public static QuerySpec Create( string? filter)
        => new QuerySpec(null, null, filter, null, -1, 0, 0, false);

    public static ValueTask<QuerySpec?> BindAsync(HttpContext context)
    {
        string? filter = context.Request.Query.Keys.Contains("filter")
            ? context.Request.Query["filter"].ToString()
            : null;

        string? search = context.Request.Query.Keys.Contains("search")
            ? context.Request.Query["search"].ToString()
            : null;

        string? select = context.Request.Query.Keys.Contains("select")
            ? context.Request.Query["select"].ToString()
            : null;

        string orderBy = context.Request.Query.Keys.Contains("order_by")
            ? context.Request.Query["order_by"].ToString()
            : "Id";

        int pageSize = context.Request.Query.Keys.Contains("pageSize")
            ? int.Parse(context.Request.Query["pageSize"])
            : 0;

        int pageNumber = context.Request.Query.Keys.Contains("pageNumber")
            ? int.Parse(context.Request.Query["pageNumber"])
            : 0;

        int skipCount = context.Request.Query.Keys.Contains("skipCount")
            ? int.Parse(context.Request.Query["skipCount"])
            : 0;

        bool paging = context.Request.Query.Keys.Contains("paging")
            ? Convert.ToBoolean(context.Request.Query["paging"])
            : false;

        var request = new QuerySpec(select, search, filter, orderBy, pageSize, pageNumber, skipCount, paging);
        return ValueTask.FromResult<QuerySpec?>(request);
    }
}

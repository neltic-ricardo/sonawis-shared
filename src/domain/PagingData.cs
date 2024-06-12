namespace Sonawis.Shared.Domain;
public class PagingData<T>
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
    public int TotalRowsCount { get; set; } = 0;
    public int TotalPages { get; set; } = 0;
    public int Total { get; set; } = 0;
    public bool ExistsRowsAfter { get; set; } = false;
    public bool ExistsRowsBefore { get; set; } = false;
    public bool ExistsRows { get { return TotalRowsCount > 0; } }
    public IEnumerable<T> Data { get; set; } = new List<T>();
}

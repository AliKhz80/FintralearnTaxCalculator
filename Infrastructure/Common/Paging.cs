using System.Dynamic;

namespace Infrastructure.Common
{
    /// <summary>
    /// Generic paging wrapper for paginated query results.
    /// </summary>
    public sealed class Paging<T>
    {
        public Paging()
        {
            Data        = [];
            Filters     = [];
            PageNumber  = 1;
            PageSize    = 10;
            TotalCount  = 0;
        }

        public List<T>              Data        { get; set; }
        public List<ExpandoObject>  Filters     { get; set; }
        public int                  PageNumber  { get; set; }
        public int                  PageSize    { get; set; }
        public int                  TotalCount  { get; set; }
    }
}

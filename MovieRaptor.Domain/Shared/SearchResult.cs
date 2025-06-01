namespace MovieRaptor.Domain.Shared
{
    public class SearchResult<T>
    {
        public int Page { get; set; }
        public int TotalResutls { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<T> Results { get; set; } = [];
    }
}

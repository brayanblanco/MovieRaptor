namespace MovieRaptor.Domain.Shared.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        Task<SearchResult<T>> GenericSearchAsync(string query, int page, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}

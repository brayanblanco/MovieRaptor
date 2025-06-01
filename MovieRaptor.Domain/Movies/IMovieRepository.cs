using MovieRaptor.Domain.Shared;

namespace MovieRaptor.Domain.Movies
{
    public interface IMovieRepository 
    {
        Task<SearchResult<Movie>> GenericSearchAsync(string query, int page, CancellationToken cancellationToken);
        Task<Movie> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}

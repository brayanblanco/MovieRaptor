using MovieRaptor.Domain.Entities;
using MovieRaptor.Domain.Shared;

namespace MovieRaptor.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<SearchResult<Movie>> GenericSearchAsync(CancellationToken cancellationToken, string query, int page = 0);
        Task<Movie> GetMovieByIdAsync(CancellationToken cancellationToken, int id);
    }
}

using MovieRaptor.Domain.Entities;

namespace MovieRaptor.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> SearchAsync(string query);
        Task<Movie> GetMovieByIdAsync(int id);
    }
}

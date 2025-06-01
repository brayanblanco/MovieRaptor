using MovieRaptor.Domain.Shared.Interfaces;

namespace MovieRaptor.Domain.Movies
{
    public interface IMovieRepository : IReadRepository<Movie> 
    {
    }
}

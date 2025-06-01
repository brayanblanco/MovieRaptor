using AutoMapper;
using MovieRaptor.Domain.Movies;
using MovieRaptor.Domain.Shared;
using TMDbLib.Client;

namespace MovieRaptor.Infrastructure.Movie
{
    public class TMDbMovieRepository(TMDbClient Client, IMapper Mapper) : IMovieRepository
    {
        public async Task<SearchResult<Domain.Movies.Movie>> GenericSearchAsync(string query, int page, CancellationToken cancellationToken)
        {
            var movies = await Client.SearchMovieAsync(query, page, false, cancellationToken: cancellationToken);
            
            return Mapper.Map<SearchResult<Domain.Movies.Movie>>(movies);
        }

        public async Task<Domain.Movies.Movie> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var movie = await Client.GetMovieAsync(id, cancellationToken: cancellationToken);

            return Mapper.Map<Domain.Movies.Movie>(movie);
        }
    }
}

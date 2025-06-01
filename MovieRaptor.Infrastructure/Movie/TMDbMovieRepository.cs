using AutoMapper;
using MovieRaptor.Domain.Interfaces;
using MovieRaptor.Domain.Shared;
using TMDbLib.Client;

namespace MovieRaptor.Infrastructure.Movie
{
    public class TMDbMovieRepository(TMDbClient Client, IMapper Mapper) : IMovieRepository
    {
        public async Task<SearchResult<Domain.Entities.Movie>> GenericSearchAsync(CancellationToken cancellationToken, string query, int page = 0)
        {
            var movies = await Client.SearchMovieAsync(query, page, false, cancellationToken: cancellationToken);
            
            return Mapper.Map<SearchResult<Domain.Entities.Movie>>(movies);
        }

        public async Task<Domain.Entities.Movie> GetMovieByIdAsync(CancellationToken cancellationToken, int id)
        {
            var movie = await Client.GetMovieAsync(id);

            return Mapper.Map<Domain.Entities.Movie>(movie);
        }
    }
}

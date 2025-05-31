using MovieRaptor.Domain.Entities;
using MovieRaptor.Domain.Interfaces;
using TMDbLib.Client;

namespace MovieRaptor.Infrastructure
{
    public class TMDbMovieRepository(TMDbClient _client) : IMovieRepository
    {
        public Task<IEnumerable<Movie>> SearchAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _client.GetMovieAsync(id);

            if (movie == null)
                return null;

            return new Movie { Id = movie.Id, Title = movie.Title };
        }
    }
}

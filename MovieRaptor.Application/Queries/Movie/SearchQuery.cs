using MediatR;
using MovieRaptor.Domain.Interfaces;

namespace MovieRaptor.Application.Queries.Movie
{
    public record SearchQuery(string Query) : IRequest<IEnumerable<Domain.Entities.Movie>>;

    public class SearchQueryHandler(IMovieRepository movieRepository) : IRequestHandler<SearchQuery, IEnumerable<Domain.Entities.Movie>>
    {
        public Task<IEnumerable<Domain.Entities.Movie>> Handle(SearchQuery request, CancellationToken cancellationToken)
        {
            return movieRepository.SearchAsync(request.Query);
        }
    }
}

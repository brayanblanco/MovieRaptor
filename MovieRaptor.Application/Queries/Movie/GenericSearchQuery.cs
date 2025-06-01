using AutoMapper;
using MediatR;
using MovieRaptor.Domain.Movies;
using MovieRaptor.Domain.Shared;

namespace MovieRaptor.Application.Queries.Movie
{
    public record GenericSearchMovieDto(int Id, string Title);

    public record GenericSearchQuery(string Query, int Page) : IRequest<SearchResult<GenericSearchMovieDto>>;

    public class SearchQueryHandler(IMovieRepository movieRepository, IMapper mapper) : IRequestHandler<GenericSearchQuery, SearchResult<GenericSearchMovieDto>>
    {
        public async Task<SearchResult<GenericSearchMovieDto>> Handle(GenericSearchQuery request, CancellationToken cancellationToken)
        {
            var movies = await movieRepository.GenericSearchAsync(request.Query, request.Page, cancellationToken);
            
            return mapper.Map<SearchResult<GenericSearchMovieDto>>(movies);
        }
    }
}

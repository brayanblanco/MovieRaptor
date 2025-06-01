using AutoMapper;
using MediatR;
using MovieRaptor.Domain.Interfaces;
using MovieRaptor.Domain.Shared;

namespace MovieRaptor.Application.Queries.Movie
{
    public record GenericSearchQuery(string Query, int Page) : IRequest<SearchResult<MovieDto>>;

    public class SearchQueryHandler(IMovieRepository movieRepository, IMapper mapper) : IRequestHandler<GenericSearchQuery, SearchResult<MovieDto>>
    {
        public async Task<SearchResult<MovieDto>> Handle(GenericSearchQuery request, CancellationToken cancellationToken)
        {
            var movie = await movieRepository.GenericSearchAsync(cancellationToken, request.Query, request.Page);

            return mapper.Map<SearchResult<MovieDto>>(movie);
        }
    }
}

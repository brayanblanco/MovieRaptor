using AutoMapper;
using MediatR;
using MovieRaptor.Domain.Movies;
using MovieRaptor.Domain.Shared;

namespace MovieRaptor.Application.Queries.User
{
    public record GenericSearchUserDto(Guid Id, string Name);
    public record GenericSearchQuery(string Query, int Page) : IRequest<SearchResult<GenericSearchUserDto>>;

    public class SearchQueryHandler(IMovieRepository movieRepository, IMapper mapper) : IRequestHandler<GenericSearchQuery, SearchResult<GenericSearchUserDto>>
    {
        public async Task<SearchResult<GenericSearchUserDto>> Handle(GenericSearchQuery request, CancellationToken cancellationToken)
        {
            var movie = await movieRepository.GenericSearchAsync(request.Query, request.Page, cancellationToken);

            return mapper.Map<SearchResult<GenericSearchUserDto>>(movie);
        }
    }
}

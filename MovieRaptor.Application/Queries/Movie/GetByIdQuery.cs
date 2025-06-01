using AutoMapper;
using MediatR;
using MovieRaptor.Domain.Interfaces;

namespace MovieRaptor.Application.Queries.Movie
{
    public record GetByIdQuery(int Id) : IRequest<MovieDto>;

    public record MovieDto(int Id, string Title);

    public class GetByIdQueryHandler(IMovieRepository movieRepository, IMapper mapper) : IRequestHandler<GetByIdQuery, MovieDto>
    {
        public async Task<MovieDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await movieRepository.GetMovieByIdAsync(cancellationToken, request.Id);

            return mapper.Map<MovieDto>(movie);
        }
    }
}

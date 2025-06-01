using AutoMapper;
using MediatR;
using MovieRaptor.Domain.Movies;

namespace MovieRaptor.Application.Queries.Movie
{
    public record GetByIdMovieDto(int Id, string Title, string OriginalTitle, string TagLine);

    public record GetByIdQuery(int Id) : IRequest<GetByIdMovieDto>;

    public class GetByIdQueryHandler(IMovieRepository movieRepository, IMapper mapper) : IRequestHandler<GetByIdQuery, GetByIdMovieDto>
    {
        public async Task<GetByIdMovieDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await movieRepository.GetByIdAsync(request.Id, cancellationToken);
            
            return mapper.Map<GetByIdMovieDto>(movie);
        }
    }
}

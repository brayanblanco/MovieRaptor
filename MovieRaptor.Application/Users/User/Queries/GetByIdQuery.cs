using AutoMapper;
using MediatR;
using MovieRaptor.Domain.Users;

namespace MovieRaptor.Application.Users.User.Queries
{
    public record GetByIdUserDto(Guid Id, string Name);

    public record GetByIdQuery(int Id) : IRequest<GetByIdUserDto>;

    public record MovieDto(int Id, string Title);

    public class GetByIdQueryHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetByIdQuery, GetByIdUserDto>
    {
        public async Task<GetByIdUserDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await userRepository.GetByIdAsync(request.Id, cancellationToken);

            return mapper.Map<GetByIdUserDto>(movie);
        }
    }
}

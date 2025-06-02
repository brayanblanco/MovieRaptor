using AutoMapper;
using MediatR;
using MovieRaptor.Domain.Users;

namespace MovieRaptor.Application.Users.User.Commands
{
    public record CreateUserDTO(string Username);

    public record CreateCommand(CreateUserDTO User) : IRequest<int>;

    public class GetByIdHandler(IUserRepository userRepository) : IRequestHandler<CreateCommand, int>
    {
        public async Task<int> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var user = Domain.Users.User.Create(request.User.Username);
            return await userRepository.CreateAsync(user, cancellationToken);
        }
    }
}

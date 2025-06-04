using System.ComponentModel.DataAnnotations;
using MediatR;
using MovieRaptor.Domain.Users;

namespace MovieRaptor.Application.Users.User.Commands
{
    public record CreateUserDTO([Required]string Username, [Required]string Email, string? Name);

    public record CreateCommand(CreateUserDTO User) : IRequest<int>;

    public class GetByIdHandler(IUserRepository userRepository) : IRequestHandler<CreateCommand, int>
    {
        public async Task<int> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var userToCreate = request.User;
            var user = Domain.Users.User.Create(userToCreate.Username, userToCreate.Email);

            if (!string.IsNullOrEmpty(userToCreate.Email))
                user.Name = userToCreate.Name;

            return await userRepository.CreateAsync(user, cancellationToken);
        }
    }
}

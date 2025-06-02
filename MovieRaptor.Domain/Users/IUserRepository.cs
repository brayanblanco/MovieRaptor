using MovieRaptor.Domain.Shared;

namespace MovieRaptor.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<int> CreateAsync(User entity, CancellationToken cancelationToken);
    }
}

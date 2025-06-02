using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieRaptor.Domain.Users;

namespace MovieRaptor.Infrastructure.Users.User
{
    public class PostgreSqlUserRepository(UsersDbContext Context, IMapper Mapper) : IUserRepository
    {
        public async Task<int> CreateAsync(Domain.Users.User entity, CancellationToken cancelationToken)
        {
            var user = Mapper.Map<UserEntity>(entity);

            await Context.Users.AddAsync(user, cancelationToken);
            await Context.SaveChangesAsync(cancelationToken);

            return user.Id;
        }

        public async Task<Domain.Users.User> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var query = Context.Users.AsQueryable<UserEntity>();

            var user = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return Mapper.Map<Domain.Users.User>(user);
        }
    }
}

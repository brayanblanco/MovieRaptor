using Microsoft.EntityFrameworkCore;
using MovieRaptor.Infrastructure.Users.User;

namespace MovieRaptor.Infrastructure.Users
{
    public class UsersDbContext(DbContextOptions<UsersDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<UserEntity> Users { get; set;  }
    }
}

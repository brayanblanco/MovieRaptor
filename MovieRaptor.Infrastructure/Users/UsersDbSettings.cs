using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace MovieRaptor.Infrastructure.Users
{
    public class UsersDbSettings
    {
        public static string SectionName => "DbConnections:UsersDb";

        public string Host { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string ConnectionString => $"Host={Host}; Database={Database}; Username={User}; Password={Password}";
    }
}

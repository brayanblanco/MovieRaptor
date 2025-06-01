namespace MovieRaptor.Domain.Users
{
    public class User
    {
        public required Guid Id { get; set; }
        public required string UserName { get; set; }
    }
}

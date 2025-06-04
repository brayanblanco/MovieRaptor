namespace MovieRaptor.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string? Name { get; set; }

        private User(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public static User Create(string username, string email)
        {
            return new User(username, email);
        }
    }
}

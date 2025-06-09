namespace MovieRaptor.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }

        private User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public static User Create(string username, string email, string password)
        {
            return new User(username, email, password);
        }
    }
}

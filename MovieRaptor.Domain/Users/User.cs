namespace MovieRaptor.Domain.Users
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }

        private User(int id, string username)
        {
            Id = id;
            Username = username;
        }

        public static User Create(string username)
        {
            return new User(1, username);
        }
    }
}

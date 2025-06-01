namespace MovieRaptor.Domain.Movies
{
    public class Movie
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string OriginalTitle { get; set; }
        public required string TagLine { get; set; }
    }
}
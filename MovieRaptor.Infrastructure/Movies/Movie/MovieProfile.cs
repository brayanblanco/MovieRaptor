using AutoMapper;

namespace MovieRaptor.Infrastructure.Movies.Movie
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<TMDbLib.Objects.Movies.Movie, Domain.Movies.Movie>();
            CreateMap<TMDbLib.Objects.Search.SearchMovie, Domain.Movies.Movie>();
        }
    }
}

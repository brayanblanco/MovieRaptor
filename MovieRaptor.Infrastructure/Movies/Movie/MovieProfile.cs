using AutoMapper;

namespace MovieRaptor.Infrastructure.Movies.Movie
{
    public class SearchResultProfile : Profile
    {
        public SearchResultProfile()
        {
            CreateMap<TMDbLib.Objects.Movies.Movie, Domain.Movies.Movie>();
            CreateMap<TMDbLib.Objects.Search.SearchMovie, Domain.Movies.Movie>();
        }
    }
}

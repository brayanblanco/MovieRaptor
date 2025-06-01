using AutoMapper;

namespace MovieRaptor.Application.Queries.Movie
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<Domain.Movies.Movie, GetByIdMovieDto>();
            CreateMap<Domain.Movies.Movie, GenericSearchMovieDto>();
        }
    }
}

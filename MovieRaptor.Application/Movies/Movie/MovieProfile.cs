using AutoMapper;
using MovieRaptor.Application.Movies.Movie.Queries;

namespace MovieRaptor.Application.Movies.Movie
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

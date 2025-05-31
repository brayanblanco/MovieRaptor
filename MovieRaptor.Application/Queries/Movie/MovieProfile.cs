using AutoMapper;

namespace MovieRaptor.Application.Queries.Movie
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<Domain.Entities.Movie, MovieDto>();
        }
    }
}

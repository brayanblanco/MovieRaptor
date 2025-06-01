using AutoMapper;
using MovieRaptor.Application.Queries.Movie;
using MovieRaptor.Domain.Shared;

namespace MovieRaptor.Infrastructure.Shared
{
    public class SearchResultProfile : Profile
    {
        public SearchResultProfile()
        {
            CreateMap<SearchResult<Domain.Movies.Movie>, SearchResult<GenericSearchMovieDto>>();
        }
    }
}

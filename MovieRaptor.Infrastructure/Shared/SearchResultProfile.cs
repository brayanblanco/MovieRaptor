using AutoMapper;
using MovieRaptor.Domain.Shared;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace MovieRaptor.Infrastructure.Shared
{
    public class SearchResultProfile : Profile
    {
        public SearchResultProfile()
        {
            CreateMap<SearchContainer<SearchMovie>, SearchResult<Domain.Entities.Movie>>();
        }
    }
}

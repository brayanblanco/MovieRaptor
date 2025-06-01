using AutoMapper;

namespace MovieRaptor.Application.Queries.User
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Domain.Users.User, GetByIdUserDto>();
            CreateMap<Domain.Users.User, GenericSearchUserDto>();
        }
    }
}

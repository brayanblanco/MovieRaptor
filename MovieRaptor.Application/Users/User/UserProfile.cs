using AutoMapper;
using MovieRaptor.Application.Users.User.Queries;

namespace MovieRaptor.Application.Users.User
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Domain.Users.User, GetByIdUserDto>();
        }
    }
}

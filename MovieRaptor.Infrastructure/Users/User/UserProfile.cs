using AutoMapper;

namespace MovieRaptor.Infrastructure.Users.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, Domain.Users.User>();
            CreateMap<Domain.Users.User, UserEntity>();
        }
    }
}

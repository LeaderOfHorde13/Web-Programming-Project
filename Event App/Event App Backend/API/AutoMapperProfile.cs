using AutoMapper;
using DTO.ContentModels;
using DTO.Friend;
using DTO;
using Models.ContentModels;
using Models.Friend;
using Models;

namespace API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Base
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            //Auth
            CreateMap<UserAuthDto, User>();
            CreateMap<User, UserAuthDto>();

            //ContentModels
            CreateMap<Content, ContentDto>();
            CreateMap<ContentDto, Content>();
            CreateMap<ContentStatistics, ContentStatisticsDto>();
            CreateMap<ContentStatisticsDto, ContentStatistics>();

            //Friend
            CreateMap<Friendship, FriendshipDto>();
            CreateMap<FriendshipDto, Friendship>();
            CreateMap<FriendshipStatus, FriendshipStatusDto>();
            CreateMap<FriendshipStatusDto, FriendshipStatus>();
        }
    }
}

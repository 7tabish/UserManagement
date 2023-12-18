using AutoMapper;
using OA.Data;

namespace OA.Service
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDTO, UserModel>();
            CreateMap<UserModel, UserOutputDTO>();
            CreateMap<UserOutputDTO, UserModel>();
        }
    }
}

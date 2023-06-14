using AutoMapper;
using Fatec.Domain.Entities.Address;
using Fatec.Domain.Entities.Job;
using Fatec.Domain.Entities.Request;
using Fatec.Domain.Entities.User;
using ProjectFatec.WebApi.Models.Request;

namespace ProjectFatec.WebApi.Mapper.Profiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<UserRequest, User>();
            CreateMap<UserUpdateRequest, User>();
            CreateMap<AddressRequest, Address>();
            CreateMap<RequestRequest, Request>();
            CreateMap<JobRequest, Job>();
        }
    }
}
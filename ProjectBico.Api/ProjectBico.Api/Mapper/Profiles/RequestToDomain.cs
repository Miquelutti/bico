using AutoMapper;
using Bico.Domain.Services.Ecryption;
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
            CreateMap<UserRequest, User>().ForMember(m => m.Password, n => n.MapFrom(o => EncryptionService.PasswordEcryption(o.Password)));
            CreateMap<UserUpdateRequest, User>();
            CreateMap<AddressRequest, Address>();
            CreateMap<RequestRequest, Request>();
            CreateMap<JobRequest, Job>();
        }
    }
}
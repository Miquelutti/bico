using AutoMapper;
using Bico.Domain.Entities.User;
using Fatec.Domain.Entities.Address;
using Fatec.Domain.Entities.Job;
using Fatec.Domain.Entities.JobCategory;
using Fatec.Domain.Entities.Request;
using Fatec.Domain.Entities.User;
using ProjectFatec.WebApi.Models.Response.ViewModels;

namespace ProjectFatec.WebApi.Mapper.Profiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<User, AuthenticateResponse>();
            CreateMap<Job, JobViewModel>();
            CreateMap<JobCategory, JobCategoryViewModel>();
            CreateMap<Job, JobDetailsViewModel>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Request, RequestViewModel>();
            CreateMap<Request, RequestDetailsViewModel>();
        }
    }
}

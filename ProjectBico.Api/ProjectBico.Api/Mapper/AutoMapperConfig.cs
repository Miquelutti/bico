using AutoMapper;
using ProjectFatec.WebApi.Mapper.Profiles;

namespace ProjectFatec.WebApi.Mapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile<RequestToDomain>();
                config.AddProfile<DomainToResponse>();
            });
        }
    }
}

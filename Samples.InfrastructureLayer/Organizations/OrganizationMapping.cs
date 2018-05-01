using AutoMapper;

namespace Samples.InfrastructureLayer.Organizations
{
    public class OrganizationMapping : Profile
    {
        public OrganizationMapping()
        {
            CreateMap<OrganizationDao, OrganizationDto>()
                .ForMember(organizationDto => organizationDto.Id, dest => dest.MapFrom(organizationDao => organizationDao.Id.ToString()));
        }
    }
}
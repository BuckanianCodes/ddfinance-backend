

using AutoMapper;
using backend.DTO;
using backend.models;

namespace backend.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<InsuranceDto,Insurance>();
            CreateMap<Insurance,InsuranceDto>();
        }
    }
}
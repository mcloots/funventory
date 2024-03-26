using AutoMapper;
using EduhubDotnet.Application.Features.Programmes.Queries.GetProgrammesList;
using EduhubDotnet.Domain.Entities;

namespace EduhubDotnet.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Programme, ProgrammeListVm>().ReverseMap();
        }
    }
}

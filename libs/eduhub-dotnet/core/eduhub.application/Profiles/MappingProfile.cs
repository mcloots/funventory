using AutoMapper;
using EduhubDotnet.Application.Features.ProgrammeGroups.Commands.CreateProgrammeGroup;
using EduhubDotnet.Application.Features.ProgrammeGroups.Commands.DeleteProgrammeGroup;
using EduhubDotnet.Application.Features.ProgrammeGroups.Commands.UpdateProgrammeGroup;
using EduhubDotnet.Application.Features.ProgrammeGroups.Queries.GetProgrammeGroupsList;
using EduhubDotnet.Application.Features.Programmes.Queries.GetProgrammesList;
using EduhubDotnet.Domain.Entities;

namespace EduhubDotnet.Application.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Programme, ProgrammeListVm>().ForMember(dest => dest.ProgrammeGroup,
        opt => opt.MapFrom(src => (src.ProgrammeGroup != null) ? src.ProgrammeGroup.Description : "")).ReverseMap();

      CreateMap<ProgrammeGroup, ProgrammeGroupListVm>().ReverseMap();
      CreateMap<ProgrammeGroup, CreateProgrammeGroupCommand>().ReverseMap();
      CreateMap<ProgrammeGroup, UpdateProgrammeGroupCommand>().ReverseMap();
      CreateMap<ProgrammeGroup, DeleteProgrammeGroupCommand>().ReverseMap();
    }
  }
}

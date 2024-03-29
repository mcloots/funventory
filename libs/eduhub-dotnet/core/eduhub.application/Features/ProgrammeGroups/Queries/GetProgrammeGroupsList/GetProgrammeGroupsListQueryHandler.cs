using AutoMapper;
using EduhubDotnet.Application.Contracts.Persistence;
using EduhubDotnet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.ProgrammeGroups.Queries.GetProgrammeGroupsList
{
  public class GetProgrammeGroupsListQueryHandler : IRequestHandler<GetProgrammeGroupsListQuery, List<ProgrammeGroupListVm>>
  {
    private readonly IAsyncRepository<Domain.Entities.ProgrammeGroup> _programmeGroupRepository;
    private readonly IMapper _mapper;

    public GetProgrammeGroupsListQueryHandler(IMapper mapper, IAsyncRepository<ProgrammeGroup> programmeGroupRepository)
    {
      _mapper = mapper;
      _programmeGroupRepository = programmeGroupRepository;
    }

    public async Task<List<ProgrammeGroupListVm>> Handle(GetProgrammeGroupsListQuery request, CancellationToken cancellationToken)
    {
      var allProgrammeGroups = (await _programmeGroupRepository.ListAllAsync()).OrderBy(x => x.Description);
      return _mapper.Map<List<ProgrammeGroupListVm>>(allProgrammeGroups);
    }
  }
}

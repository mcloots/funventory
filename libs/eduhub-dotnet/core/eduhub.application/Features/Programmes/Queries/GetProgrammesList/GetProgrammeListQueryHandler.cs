using AutoMapper;
using EduhubDotnet.Application.Contracts.Persistence;
using EduhubDotnet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.Programmes.Queries.GetProgrammesList
{
  public class GetProgrammeListQueryHandler : IRequestHandler<GetProgrammeListQuery, List<ProgrammeListVm>>
  {
    private readonly IAsyncRepository<Programme> _programmeRepository;
    private readonly IMapper _mapper;

    public GetProgrammeListQueryHandler(IMapper mapper, IAsyncRepository<Programme> programmeRepository)
    {
      _mapper = mapper;
      _programmeRepository = programmeRepository;
    }

    public async Task<List<ProgrammeListVm>> Handle(GetProgrammeListQuery request, CancellationToken cancellationToken)
    {
      var allEvents = (await _programmeRepository.ListAllAsync()).OrderBy(x => x.Name);
      return _mapper.Map<List<ProgrammeListVm>>(allEvents);
    }
  }
}

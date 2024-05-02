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
  public class GetProgrammesListQueryHandler : IRequestHandler<GetProgrammesListQuery, List<ProgrammeListVm>>
  {
    private readonly IProgrammeRepository _programmeRepository;
    private readonly IMapper _mapper;

    public GetProgrammesListQueryHandler(IMapper mapper, IProgrammeRepository programmeRepository)
    {
      _mapper = mapper;
      _programmeRepository = programmeRepository;
    }

    public async Task<List<ProgrammeListVm>> Handle(GetProgrammesListQuery request, CancellationToken cancellationToken)
    {
      var allEvents = (await _programmeRepository.GetAll(true)).OrderBy(x => x.Name);
      return _mapper.Map<List<ProgrammeListVm>>(allEvents);
    }
  }
}

using AutoMapper;
using EduhubDotnet.Application.Contracts.Persistence;
using EduhubDotnet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.ProgrammeGroups.Commands.DeleteProgrammeGroup
{
  public class DeleteProgrammeGroupCommandHandler : IRequestHandler<DeleteProgrammeGroupCommand>
  {
    private readonly IAsyncRepository<ProgrammeGroup> _pgRepository;
    private readonly IMapper _mapper;

    public DeleteProgrammeGroupCommandHandler(IMapper mapper, IAsyncRepository<ProgrammeGroup> pgRepository)
    {
      _mapper = mapper;
      _pgRepository = pgRepository;
    }

    public async Task Handle(DeleteProgrammeGroupCommand request, CancellationToken cancellationToken)
    {
      var programmeGroupToDelete = await _pgRepository.GetByIdAsync(request.Id);

      await _pgRepository.DeleteAsync(programmeGroupToDelete);
    }
  }
}

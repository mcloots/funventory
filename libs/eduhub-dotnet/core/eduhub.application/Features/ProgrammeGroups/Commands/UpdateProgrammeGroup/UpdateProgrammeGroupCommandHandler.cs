using AutoMapper;
using EduhubDotnet.Application.Contracts.Persistence;
using EduhubDotnet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.ProgrammeGroups.Commands.UpdateProgrammeGroup
{
  public class UpdateProgrammeGroupCommandHandler : IRequestHandler<UpdateProgrammeGroupCommand>
  {
    private readonly IProgrammeGroupRepository _pgRepository;
    private readonly IMapper _mapper;

    public UpdateProgrammeGroupCommandHandler(IMapper mapper, IProgrammeGroupRepository pgRepository)
    {
      _mapper = mapper;
      _pgRepository = pgRepository;
    }

    public async Task Handle(UpdateProgrammeGroupCommand request, CancellationToken cancellationToken)
    {
      var programmeGroupToUpdate = await _pgRepository.GetByIdAsync(request.Id);

      _mapper.Map(request, programmeGroupToUpdate, typeof(UpdateProgrammeGroupCommand), typeof(ProgrammeGroup));

      var validator = new UpdateProgrammeGroupCommandValidator(_pgRepository);
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
        throw new Exceptions.ValidationException(validationResult);

      await _pgRepository.UpdateAsync(programmeGroupToUpdate);
    }
  }
}

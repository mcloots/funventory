using AutoMapper;
using EduhubDotnet.Application.Contracts.Persistence;
using EduhubDotnet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.ProgrammeGroups.Commands.CreateProgrammeGroup
{
  public class CreateProgrammeGroupCommandHandler : IRequestHandler<CreateProgrammeGroupCommand, Guid>
  {
    private readonly IProgrammeGroupRepository _pgRepository;
    private readonly IMapper _mapper;

    public CreateProgrammeGroupCommandHandler(IMapper mapper, IProgrammeGroupRepository pgRepository)
    {
      _mapper = mapper;
      _pgRepository = pgRepository;
    }

    public async Task<Guid> Handle(CreateProgrammeGroupCommand request, CancellationToken cancellationToken)
    {
      var @programmeGroup = _mapper.Map<Domain.Entities.ProgrammeGroup>(request);

      var validator = new CreateProgrammeGroupCommandValidator(_pgRepository);
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
        throw new Exceptions.ValidationException(validationResult);

      @programmeGroup = await _pgRepository.AddAsync(@programmeGroup);

      return @programmeGroup.Id;
    }
  }
}

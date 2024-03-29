using EduhubDotnet.Application.Contracts.Persistence;
using EduhubDotnet.Application.Features.ProgrammeGroups.Commands.UpdateProgrammeGroup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.ProgrammeGroups.Commands.UpdateProgrammeGroup
{
  public class UpdateProgrammeGroupCommandValidator : AbstractValidator<UpdateProgrammeGroupCommand>
  {
    private readonly IProgrammeGroupRepository _pgRepository;

    public UpdateProgrammeGroupCommandValidator(IProgrammeGroupRepository pgRepository)
    {
      _pgRepository = pgRepository;

      RuleFor(pg => pg.Description)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull();

      RuleFor(pg => pg)
        .MustAsync(DescriptionUnique)
        .WithMessage("A programme group with the same description already exists.");
    }

    private async Task<bool> DescriptionUnique(UpdateProgrammeGroupCommand e, CancellationToken token)
    {
      return !await _pgRepository.IsDescriptionUnique(e.Description, e.Id);
    }
  }
}

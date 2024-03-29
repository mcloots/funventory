using EduhubDotnet.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.ProgrammeGroups.Commands.CreateProgrammeGroup
{
  public class CreateProgrammeGroupCommandValidator : AbstractValidator<CreateProgrammeGroupCommand>
  {
    private readonly IProgrammeGroupRepository _pgRepository;

    public CreateProgrammeGroupCommandValidator(IProgrammeGroupRepository pgRepository)
    {
      _pgRepository = pgRepository;

      RuleFor(pg => pg.Description)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull();

      RuleFor(pg => pg)
        .MustAsync(DescriptionUnique)
        .WithMessage("A programme group with the same description already exists.");
    }

    private async Task<bool> DescriptionUnique(CreateProgrammeGroupCommand e, CancellationToken token)
    {
      return !await _pgRepository.IsDescriptionUnique(e.Description);
    }
  }
}

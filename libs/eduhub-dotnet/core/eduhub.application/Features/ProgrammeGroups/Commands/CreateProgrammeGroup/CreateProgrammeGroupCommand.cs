using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.ProgrammeGroups.Commands.CreateProgrammeGroup
{
  public class CreateProgrammeGroupCommand : IRequest<Guid>
  {
    public string Description { get; set; }
  }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.ProgrammeGroups.Commands.UpdateProgrammeGroup
{
  public class UpdateProgrammeGroupCommand : IRequest
  {
    public Guid Id { get; set; }
    public string Description { get; set; }
  }
}

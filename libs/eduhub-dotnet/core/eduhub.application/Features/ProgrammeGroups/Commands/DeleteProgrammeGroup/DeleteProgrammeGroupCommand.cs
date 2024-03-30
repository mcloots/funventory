using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.ProgrammeGroups.Commands.DeleteProgrammeGroup
{
  public class DeleteProgrammeGroupCommand : IRequest
  {
    public Guid Id { get; set; }
  }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.Programmes.Queries.GetProgrammesList
{
  public class GetProgrammesListQuery : IRequest<List<ProgrammeListVm>>
  {
  }
}

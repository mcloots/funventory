using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Application.Features.Programmes.Queries.GetProgrammesList
{
  public class ProgrammeListVm
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public string ProgrammeGroup { get; set; }
  }
}

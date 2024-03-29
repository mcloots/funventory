
using EduhubDotnet.Domain.Entities;

namespace EduhubDotnet.Application.Contracts.Persistence
{
  public interface IProgrammeGroupRepository : IAsyncRepository<ProgrammeGroup>
  {
    Task<bool> IsDescriptionUnique(string description, Guid? id = null);
  }
}

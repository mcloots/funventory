
using EduhubDotnet.Domain.Entities;

namespace EduhubDotnet.Application.Contracts.Persistence
{
  public interface IProgrammeRepository : IAsyncRepository<Programme>
  {
    Task<List<Programme>> GetAll(bool isProgrammeGroupIncluded = false);
  }
}

using EduhubDotnet.Application.Contracts.Persistence;
using EduhubDotnet.Domain.Entities;
using EduhubDotnet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduhubDotnet.Persistence.Repositories
{
  public class ProgrammeGroupRepository : BaseRepository<ProgrammeGroup>, IProgrammeGroupRepository
  {
    public ProgrammeGroupRepository(EduHubDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> IsDescriptionUnique(string description, Guid? id = null)
    {
      if (id == null)
      {
        return Task.FromResult(_dbContext.ProgrammeGroups.Any(pg => pg.Description.ToLower() == description.ToLower()));
      }
      else
      {
        // The uniqueness of the description should only be compared with other programme groups on updating
        return Task.FromResult(_dbContext.ProgrammeGroups.Where(pg => pg.Id != id).Any(pg => pg.Description.ToLower() == description.ToLower()));
      }
    }
  }
}

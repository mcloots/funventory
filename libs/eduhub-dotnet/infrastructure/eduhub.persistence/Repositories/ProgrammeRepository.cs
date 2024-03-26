using EduhubDotnet.Application.Contracts.Persistence;
using EduhubDotnet.Domain.Entities;
using EduhubDotnet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduhubDotnet.Persistence.Repositories
{
    public class ProgrammeRepository : BaseRepository<Programme>, IProgrammeRepository
    {
        public ProgrammeRepository(EduHubDbContext dbContext) : base(dbContext)
        {
        }
    }
}

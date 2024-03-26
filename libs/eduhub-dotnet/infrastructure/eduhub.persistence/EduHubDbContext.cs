using EduhubDotnet.Domain.Common;
using EduhubDotnet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduhubDotnet.Persistence
{
  public class EduHubDbContext : DbContext
  {
    public EduHubDbContext(DbContextOptions<EduHubDbContext> options)
    : base(options)
    {
    }

    public DbSet<ProgrammeGroup> ProgrammeGroups { get; set; }
    public DbSet<Programme> Programmes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(EduHubDbContext).Assembly);

      modelBuilder.Entity<ProgrammeGroup>().ToTable("ProgrammeGroup");
      modelBuilder.Entity<Programme>().ToTable("Programme");

      var programmeGroupGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");

      modelBuilder.Entity<ProgrammeGroup>().HasData(new ProgrammeGroup
      {
        Id = programmeGroupGuid,
        Description = "IT Bachelors"
      });

      modelBuilder.Entity<Programme>().HasData(new Programme
      {
        Id = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
        ProgrammeGroupId = programmeGroupGuid,
        Name = "Toegepaste Informatica",
        Language = "NL"
      });
      modelBuilder.Entity<Programme>().HasData(new Programme
      {
        Id = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
        ProgrammeGroupId = programmeGroupGuid,
        Name = "Elektronica-ICT",
        Language = "NL"
      });
      modelBuilder.Entity<Programme>().HasData(new Programme
      {
        Id = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
        Name = "Applied Computer Science",
        Language = "EN"
      });

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
      {
        switch (entry.State)
        {
          case EntityState.Added:
            entry.Entity.CreatedDate = DateTime.Now;
            break;
          case EntityState.Modified:
            entry.Entity.LastModifiedDate = DateTime.Now;
            break;
        }
      }
      return base.SaveChangesAsync(cancellationToken);
    }
  }
}

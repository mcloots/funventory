using EduhubDotnet.Domain.Common;

namespace EduhubDotnet.Domain.Entities
{
  public class Programme : AuditableEntity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public Guid? ProgrammeGroupId { get; set; }
    public ProgrammeGroup? ProgrammeGroup { get; set; }
  }
}

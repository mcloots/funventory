using EduhubDotnet.Domain.Common;

namespace EduhubDotnet.Domain.Entities
{
    public class ProgrammeGroup : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}

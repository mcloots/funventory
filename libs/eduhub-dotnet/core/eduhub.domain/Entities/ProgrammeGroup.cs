using EduHub.Domain.Common;

namespace EduHub.Domain.Entities
{
    public class ProgrammeGroup : AuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

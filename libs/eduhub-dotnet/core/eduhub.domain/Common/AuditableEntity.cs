namespace EduhubDotnet.Domain.Common
{
    public class AuditableEntity //Logging support for tracking purposes
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

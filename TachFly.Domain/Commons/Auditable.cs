namespace TachFly.Domain.Commons
{
    public abstract class Auditable : BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
    }
}

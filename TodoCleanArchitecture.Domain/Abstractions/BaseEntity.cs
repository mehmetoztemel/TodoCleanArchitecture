namespace TodoCleanArchitecture.Domain.Abstractions
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

namespace TodoCleanArchitecture.Domain.Entities
{
    public sealed class Todo : BaseEntity
    {
        public string Work { get; set; } = default!;
        public DateOnly DeadLine { get; set; }
        public bool IsCompleted { get; set; }
    }
}
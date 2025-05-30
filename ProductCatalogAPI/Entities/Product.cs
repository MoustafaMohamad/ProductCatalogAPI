namespace Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsActive => DateTime.UtcNow >= StartDate && DateTime.UtcNow <= StartDate + Duration;

    }
}

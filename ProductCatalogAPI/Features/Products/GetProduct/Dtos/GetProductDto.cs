namespace ProductCatalogAPI.Features.Products.GetProduct.Dtos
{
    public record GetProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}

namespace ProductCatalogAPI.Features.Products.AddProduct
{
    public record AddProductEnpointRequest
    {

        public string Name { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

    }
}

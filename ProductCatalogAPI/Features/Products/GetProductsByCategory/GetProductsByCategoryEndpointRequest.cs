namespace ProductCatalogAPI.Features.Products.GetProductsByCategory
{
    public record GetProductsByCategoryEndpointRequest
    {
        public Guid CategoryId { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}

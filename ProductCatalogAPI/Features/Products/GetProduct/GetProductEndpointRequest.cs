namespace ProductCatalogAPI.Features.Products.GetProduct
{
    public record GetProductEndpointRequest
    {
        public Guid Id { get; init; }

    }
}

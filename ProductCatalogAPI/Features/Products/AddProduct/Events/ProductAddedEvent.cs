namespace ProductCatalogAPI.Features.Products.AddProduct.Events
{
    public sealed record ProductAddedEvent(Guid ProductId, string Name, DateTime CreationDate,
       Guid CreatedByUserId) : INotification;

}

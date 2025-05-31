namespace ProductCatalogAPI.Features.Common.Data
{
    public enum ErrorCode
    {
        None,
        InvalidInput,

        ProductNotFound = 1000,

        CategoryNotFound = 2000,

        ClientClosedRequest = 499,


        Unauthorized = 401,

    }
}

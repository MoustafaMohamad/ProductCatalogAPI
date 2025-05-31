using System.ComponentModel;

namespace ProductCatalogAPI.Features.Common.Data
{
    public enum ErrorCode
    {
        [Description("No error.")]
        None,

        [Description("Invalid input data.")]
        InvalidInput,

        [Description("Product not found.")]
        ProductNotFound = 1000,

        [Description("Category not found.")]
        CategoryNotFound = 2000,

        [Description("Client closed the request before the server could respond.")]
        ClientClosedRequest = 499,

        [Description("Unauthorized access.")]
        Unauthorized = 401,

        [Description("An unknown error occurred.")]
        UnKnown = 2001
    }

}
}

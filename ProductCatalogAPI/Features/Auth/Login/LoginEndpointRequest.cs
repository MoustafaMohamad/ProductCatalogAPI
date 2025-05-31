namespace ProductCatalogAPI.Features.Auth.Login
{
    public record LoginEndpointRequest
    {
        public string Username { get; init; } = string.Empty;

        public string Password { get; init; } = string.Empty;
    }
}

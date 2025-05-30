namespace ProductCatalogAPI.Features.Auth.Register
{
    public record RegisterEndpointRequest(string Username, string Name, string Email, string Password);
}

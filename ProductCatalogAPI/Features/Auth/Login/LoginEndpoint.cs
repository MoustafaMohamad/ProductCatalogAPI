using ProductCatalogAPI.Features.Auth.Login.Commands;

namespace ProductCatalogAPI.Features.Auth.Login
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<EndpointResponse<string>> LoginEndpoint([FromBody] LoginEndpointRequest request)
        {
            var loginResult = await _mediator.Send(new LoginCommand(request.Username, request.Password));

            if (!loginResult.IsSuccess)
            {
                return EndpointResponse<string>.Failure(loginResult.ErrorCode);
            }

            return EndpointResponse<string>.Success(loginResult.Data, loginResult.Message);
        }

    }
}

namespace ProductCatalogAPI.Features.Auth.Register
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
        [HttpPost("register")]
        public async Task<EndpointResponse<bool>> RegisterEndpoint([FromBody] RegisterEndpointRequest request)
        {
            var registerResult = await _mediator.Send(new RegisterCommand(request.Username, request.Name, request.Email, request.Password));
            if (!registerResult.IsSuccess)
            {
                return EndpointResponse<bool>.Failure(registerResult.ErrorCode);
            }

            return EndpointResponse<bool>.Success(registerResult.Data, registerResult.Message);
        }
    }
}


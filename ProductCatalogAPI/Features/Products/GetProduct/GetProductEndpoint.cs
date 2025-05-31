namespace ProductCatalogAPI.Features.Products.GetProduct
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "Admin")]

        [HttpGet("get-product")]
        public async Task<EndpointResponse<GetProductViewModel>> GetProductEndpoint([FromQuery] GetProductEndpointRequest request)
        {
            var productDtoResult = await _mediator.Send(new GetProductQuery(request.Id));
            if (!productDtoResult.IsSuccess)
            {
                return EndpointResponse<GetProductViewModel>.Failure(productDtoResult.ErrorCode);
            }
            var productViewModel = productDtoResult.Data.MapOne<GetProductViewModel>();
            return EndpointResponse<GetProductViewModel>.Success(productViewModel);
        }
    }
}

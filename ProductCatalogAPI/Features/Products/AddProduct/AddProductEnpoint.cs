namespace ProductCatalogAPI.Features.Products.AddProduct
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-product")]
        [Authorize(Roles = "Admin")]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<EndpointResponse<bool>> AddProductEndpointE([FromBody] AddProductEnpointRequest request)
        {
            var addProductResult = await _mediator.Send(
                new AddProductCommand(request.Name, request.StartDate, request.Duration, request.Price, request.CategoryId));
            if (!addProductResult.IsSuccess)
            {
                return EndpointResponse<bool>.Failure(addProductResult.ErrorCode);
            }
            return EndpointResponse<bool>.Success(true);
        }
    }



}

namespace ProductCatalogAPI.Features.Products.EditProduct
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

        [HttpPut("edit-product")]
        [Authorize(Roles = "Admin")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<EndpointResponse<bool>> EditProductEndpoint([FromBody] EditProductEndpointRequst request)
        {
            var editProductResult = await _mediator.Send(
                new EditProductCommand(request.Id, request.Name, request.StartDate, request.Duration, request.Price, request.CategoryId));
            if (!editProductResult.IsSuccess)
            {
                return EndpointResponse<bool>.Failure(editProductResult.ErrorCode);
            }
            return EndpointResponse<bool>.Success(true);
        }


    }
}

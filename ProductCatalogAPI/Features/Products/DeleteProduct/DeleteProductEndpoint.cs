namespace ProductCatalogAPI.Features.Products.DeleteProduct
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
        [HttpDelete("delete-product")]
        [Authorize(Roles = "Admin")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<EndpointResponse<bool>> DeleteProductEndpoint([FromBody] DeleteProductEndpointRequest request)
        {
            var deleteProductResult = await _mediator.Send(new DeleteProductCommand(request.ProductId));
            if (!deleteProductResult.IsSuccess)
            {
                return EndpointResponse<bool>.Failure(deleteProductResult.ErrorCode);
            }
            return EndpointResponse<bool>.Success(true);
        }

    }
}

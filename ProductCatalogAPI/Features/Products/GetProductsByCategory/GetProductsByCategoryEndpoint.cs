namespace ProductCatalogAPI.Features.Products.GetProductsByCategory
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
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("get-products-by-category")]
        public async Task<EndpointResponse<IEnumerable<GetProductsByCategoryViewModel>>> GetProductsByCategoryEndpoint([FromQuery] GetProductsByCategoryEndpointRequest request)
        {
            var productsDtoResult = await _mediator.Send(new GetProductsByCategoryQuery(request.CategoryId, request.Page, request.PageSize));
            if (!productsDtoResult.IsSuccess)
            {
                return EndpointResponse<IEnumerable<GetProductsByCategoryViewModel>>.Failure(productsDtoResult.ErrorCode);
            }
            var productsViewModel = productsDtoResult.Data.items.Map<GetProductsByCategoryViewModel>();

            return EndpointResponse<IEnumerable<GetProductsByCategoryViewModel>>.Success(productsViewModel);
        }

    }
}

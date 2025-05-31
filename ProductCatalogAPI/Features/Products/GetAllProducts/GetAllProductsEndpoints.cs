namespace ProductCatalogAPI.Features.Products.GetAllProducts
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
        [HttpGet("get-all-products")]
        [Authorize(Roles = "Admin")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<EndpointResponse<IEnumerable<GetAllProductsViewModel>>> GetAllProductsEndpoint([FromQuery] GetAllProductsEndpointsRequest request)
        {
            var productsDtoResult = await _mediator.Send(new GetAllProductsQuery(request.page, request.pageSize));
            if (!productsDtoResult.IsSuccess)
            {
                return EndpointResponse<IEnumerable<GetAllProductsViewModel>>.Failure(productsDtoResult.ErrorCode);

            }
            var productsViewModel = productsDtoResult.Data.items.Map<GetAllProductsViewModel>();

            return EndpointResponse<IEnumerable<GetAllProductsViewModel>>.Success(productsViewModel);
        }
    }


}

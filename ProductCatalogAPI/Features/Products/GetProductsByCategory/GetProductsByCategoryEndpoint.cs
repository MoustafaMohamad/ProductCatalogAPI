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

        [HttpGet("get-products-by-category")]
        public async Task<EndpointResponse<PagedList<GetProductsByCategoryViewModel>>> GetProductsByCategoryEndpoint([FromQuery] GetProductsByCategoryEndpointRequest request)
        {
            var productsDtoResult = await _mediator.Send(new GetProductsByCategoryQuery(request.CategoryId, request.Page, request.PageSize));
            if (!productsDtoResult.IsSuccess)
            {
                return EndpointResponse<PagedList<GetProductsByCategoryViewModel>>.Failure(productsDtoResult.ErrorCode);
            }
            var productsViewModel = await productsDtoResult.Data.items.Map<GetProductsByCategoryViewModel>()
                .AsQueryable().ToPagedListAsync(request.Page, request.PageSize);

            return EndpointResponse<PagedList<GetProductsByCategoryViewModel>>.Success(productsViewModel);
        }

    }
}

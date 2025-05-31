using Microsoft.AspNetCore.Authorization;

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
        public async Task<EndpointResponse<PagedList<GetAllProductsViewModel>>> GetAllProductsEndpoint([FromQuery] GetAllProductsEndpointsRequest request)
        {
            var productsDtoResult = await _mediator.Send(new GetAllProductsQuery(request.page, request.pageSize));
            if (!productsDtoResult.IsSuccess)
            {
                return EndpointResponse<PagedList<GetAllProductsViewModel>>.Failure(productsDtoResult.ErrorCode);

            }
            var productsViewModel = await productsDtoResult.Data.items.Map<GetAllProductsViewModel>()
                .AsQueryable().ToPagedListAsync(request.page, request.pageSize);
            return EndpointResponse<PagedList<GetAllProductsViewModel>>.Success(productsViewModel);
        }
    }


}

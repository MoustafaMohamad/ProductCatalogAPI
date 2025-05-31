namespace ProductCatalogAPI.Features.Products.GetAllProducts.Queries
{
    public record GetAllProductsQuery(int Page, int PageSize) : IRequest<RequestResult<PagedList<GetAllProductsDto>>>;

    public sealed class GetAllProductsQueryHandler : BaseRequestHandler<GetAllProductsQuery, RequestResult<PagedList<GetAllProductsDto>>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(RequestParameters requestParameters, IProductRepository productRepository)
            : base(requestParameters)
        {
            _productRepository = productRepository;
        }
        public override async Task<RequestResult<PagedList<GetAllProductsDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var productsQuery = _productRepository.GetAll().Map<GetAllProductsDto>();
            var pagedProductsDto = await productsQuery
                .ToPagedListAsync(request.Page, request.PageSize, _cancellationToken);
            return RequestResult<PagedList<GetAllProductsDto>>.Success(pagedProductsDto);
        }
    }

}

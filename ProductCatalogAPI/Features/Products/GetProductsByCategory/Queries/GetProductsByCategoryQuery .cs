using ProductCatalogAPI.Features.Products.GetProductsByCategory.Dtos;

namespace ProductCatalogAPI.Features.Products.GetProductsByCategory.Queries
{
    public record GetProductsByCategoryQuery(Guid CategoryId, int Page, int PageSize)
        : IRequest<RequestResult<PagedList<GetAllProductsByCategoryDto>>>;

    public sealed class GetProductsByCategoryQueryHandler : BaseRequestHandler<GetProductsByCategoryQuery, RequestResult<PagedList<GetAllProductsByCategoryDto>>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsByCategoryQueryHandler(RequestParameters requestParameters, IProductRepository productRepository)
            : base(requestParameters)
        {
            _productRepository = productRepository;
        }
        public override async Task<RequestResult<PagedList<GetAllProductsByCategoryDto>>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var isCategoryExist = await _mediator.Send(new IsCategoryExistQuery(request.CategoryId));
            var productsQuery = _productRepository.GetProductsByCategory(request.CategoryId);
            if (!isCategoryExist.IsSuccess)
            {
                return RequestResult<PagedList<GetAllProductsByCategoryDto>>.Failure(isCategoryExist.ErrorCode);
            }
            var products = await productsQuery
                .OrderByDescending(p => p.StartDate)
                .Map<GetAllProductsByCategoryDto>()
                .ToPagedListAsync(request.Page, request.PageSize, _cancellationToken);
            return RequestResult<PagedList<GetAllProductsByCategoryDto>>.Success(products);
        }
    }
}

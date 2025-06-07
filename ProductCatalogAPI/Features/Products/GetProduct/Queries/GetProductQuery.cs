namespace ProductCatalogAPI.Features.Products.GetProduct.Queries
{
    public record GetProductQuery(Guid Id) : IRequest<RequestResult<GetProductDto>>;

    public class GetProductQueryHandler : BaseRequestHandler<GetProductQuery, RequestResult<GetProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(RequestParameters requestParameters, IProductRepository productRepository) : base(requestParameters)
        {
            _productRepository = productRepository;
        }



        public override async Task<RequestResult<GetProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Get(p => p.Id == request.Id);

            if (product is null)
            {
                return RequestResult<GetProductDto>.Failure(ErrorCode.ProductNotFound);
            }
            var productDto = product.Map<GetProductDto>().FirstOrDefault();
            return RequestResult<GetProductDto>.Success(productDto);
        }
    }
}

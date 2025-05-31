namespace ProductCatalogAPI.Features.Products.DeleteProduct.Commands
{
    public record DeleteProductCommand(Guid ProductId) : IRequest<RequestResult<bool>>;

    public class DeleteProductCommandHandler : BaseRequestHandler<DeleteProductCommand, RequestResult<bool>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(RequestParameters requestParameters, IProductRepository productRepository) : base(requestParameters)
        {
            _productRepository = productRepository;
        }


        public override async Task<RequestResult<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var isProductExist = await _productRepository.IsProductExistAsync(request.ProductId);
            if (!isProductExist)
            {
                return RequestResult<bool>.Failure(ErrorCode.ProductNotFound);
            }
            var deleteProduct = new Product
            {
                Id = request.ProductId
            };
            _productRepository.Delete(deleteProduct);
            return RequestResult<bool>.Success(true);
        }
    }
}

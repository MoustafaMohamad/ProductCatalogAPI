
namespace ProductCatalogAPI.Features.Products.EditProduct.Commands
{
    public record EditProductCommand(Guid Id, string Name, DateTime StartDate, TimeSpan Duration, decimal Price, Guid CategoryId)
        : IRequest<RequestResult<bool>>;

    public sealed class EditProductCommandHandler : BaseRequestHandler<EditProductCommand, RequestResult<bool>>
    {
        private readonly IProductRepository _productRepository;

        public EditProductCommandHandler(RequestParameters requestParameters, IProductRepository productRepository) : base(requestParameters)
        {
            _productRepository = productRepository;
        }

        public override async Task<RequestResult<bool>> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var isProductExist = await _productRepository.IsProductExistAsync(request.Id);
            if (!isProductExist)
            {
                return RequestResult<bool>.Failure(ErrorCode.ProductNotFound);
            }

            var isCategoryNameExist = await _mediator.Send(new IsCategoryExistQuery(request.CategoryId));
            if (!isCategoryNameExist.IsSuccess)
            {
                return RequestResult<bool>.Failure(isCategoryNameExist.ErrorCode);
            }
            var editedProduct = new Product
            {
                Id = request.Id,
                Name = request.Name,
                StartDate = request.StartDate,
                Duration = request.Duration,
                Price = request.Price,
                CategoryId = request.CategoryId

            };
            _productRepository.UpdateIncluded(editedProduct, nameof(Product.Name),
                nameof(Product.StartDate), nameof(Product.Duration), nameof(Product.Price),
                nameof(Product.CategoryId));


            return RequestResult<bool>.Success(true);
        }
    }
}

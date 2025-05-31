

namespace ProductCatalogAPI.Features.Products.AddProduct.Commands
{
    public record AddProductCommand(string Name, DateTime StartDate,
        TimeSpan Duration, decimal Price, Guid CategoryId) : IRequest<RequestResult<Guid>>;

    public sealed class AddProductCommandHandler : BaseRequestHandler<AddProductCommand, RequestResult<Guid>>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(RequestParameters requestParameters, IProductRepository productRepository) : base(requestParameters)
        {
            _productRepository = productRepository;
        }

        public override async Task<RequestResult<Guid>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var IsCategoryExistsResult = await _mediator.Send(new IsCategoryExistQuery(request.CategoryId));
            if (!IsCategoryExistsResult.IsSuccess)
            {
                return RequestResult<Guid>.Failure(IsCategoryExistsResult.ErrorCode);
            }

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreationDate = DateTime.UtcNow,
                CreatedByUserId = _userState.ID,
                StartDate = request.StartDate,
                Duration = request.Duration,
                Price = request.Price,
                CategoryId = request.CategoryId
            };
            await _productRepository.AddAsync(product);
            return RequestResult<Guid>.Success(product.Id);
        }
    }


}

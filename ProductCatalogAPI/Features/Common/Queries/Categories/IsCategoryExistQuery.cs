namespace ProductCatalogAPI.Features.Common.Queries.Categories
{
    public record IsCategoryExistQuery(Guid CategoryId) : IRequest<RequestResult<bool>>;

    public sealed class IsCategoryExistQueryHandler : BaseRequestHandler<IsCategoryExistQuery, RequestResult<bool>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public IsCategoryExistQueryHandler(RequestParameters requestParameters, ICategoryRepository categoryRepository) : base(requestParameters)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsCategoryExistQuery request, CancellationToken cancellationToken)
        {
            var isCategoryExist = await _categoryRepository.IsCategoryExistsAsync(request.CategoryId);
            if (!isCategoryExist)
            {
                return RequestResult<bool>.Failure(ErrorCode.CategoryNotFound);
            }
            return RequestResult<bool>.Success(true);
        }
    }
}

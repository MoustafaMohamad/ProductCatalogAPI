namespace ProductCatalogAPI.Features.Products.GetAllProducts.Validators
{
    public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
    {
        public GetAllProductsQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number must be greater than or equal to 1.");
            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page size must be greater than or equal to 1.");
        }
    }
}

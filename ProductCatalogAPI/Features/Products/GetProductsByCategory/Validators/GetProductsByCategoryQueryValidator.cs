namespace ProductCatalogAPI.Features.Products.GetProductsByCategory.Validators
{
    public sealed class GetProductsByCategoryQueryValidator : AbstractValidator<GetProductsByCategoryQuery>
    {
        public GetProductsByCategoryQueryValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID cannot be empty.");
            RuleFor(x => x.Page).GreaterThan(0).WithMessage("Page number must be greater than zero.");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Page size must be greater than zero.");
        }
    }


}

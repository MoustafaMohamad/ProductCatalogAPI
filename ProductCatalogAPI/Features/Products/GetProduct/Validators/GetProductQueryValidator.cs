
namespace ProductCatalogAPI.Features.Products.GetProduct.Validators
{
    public sealed class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID cannot be empty.");
        }
    }

}

namespace ProductCatalogAPI.Features.Products.DeleteProduct.Validators
{
    public sealed class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID must not be empty.")
                .NotNull().WithMessage("Product ID must not be null.");
        }
    }

}

namespace ProductCatalogAPI.Features.Products.EditProduct.Validators
{
    public sealed class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID cannot be empty.");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product name cannot be empty.");
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("Start date cannot be empty.")
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("Start date must be today or a future date.");
            RuleFor(x => x.Duration)
                .NotEmpty()
                .WithMessage("Duration cannot be empty.")
                .GreaterThan(TimeSpan.Zero)
                .WithMessage("Duration must be greater than zero.");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");

        }
    }

}



namespace ProductCatalogAPI.Features.Products.AddProduct.Validators
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(500).WithMessage("Product name cannot exceed 500 characters.");
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .GreaterThan(DateTime.UtcNow).WithMessage("Start date must be in the future.");
            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Duration is required.")
                .GreaterThan(TimeSpan.Zero).WithMessage("Duration must be greater than zero.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category ID is required.");
        }
    }

}

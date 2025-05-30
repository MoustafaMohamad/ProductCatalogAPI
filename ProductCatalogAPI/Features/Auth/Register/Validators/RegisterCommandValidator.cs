namespace ProductCatalogAPI.Features.Auth.Register.Validators
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;



        public RegisterCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters.")
                .MustAsync(BeUniqueUsernameAsync).WithMessage("Username is already in use."); ;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(BeUniqueEmailAsync).WithMessage("Email is already in use.");
            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password is required.")
               .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
               .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$")
               .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
        }

        private async Task<bool> BeUniqueEmailAsync(string email, CancellationToken cancellationToken)
        {
            return !await _userRepository.EmailIsExistAsync(email);
        }

        private async Task<bool> BeUniqueUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return !await _userRepository.UsernameIsExistAsync(username);
        }
    }
}

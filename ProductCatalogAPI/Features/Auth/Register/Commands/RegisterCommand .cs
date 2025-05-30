namespace ProductCatalogAPI.Features.Auth.Register.Commands
{
    public record RegisterCommand(string Username, string Name, string Email, string Password) :
        IRequest<RequestResult<bool>>;


    public sealed class RegisterCommandHandler : BaseRequestHandler<RegisterCommand, RequestResult<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        public RegisterCommandHandler(RequestParameters requestParameters,
            IPasswordHasher passwordHasher,
            IUserRepository userRepository) : base(requestParameters)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public override async Task<RequestResult<bool>> Handle(RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Name = request.Name,
                Email = request.Email,
                PasswordHash = _passwordHasher.Hash(request.Password),
                Role = Role.User,
                IsDeleted = false,

            };

            await _userRepository.AddAsync(newUser);
            return RequestResult<bool>.Success(true, "User registered successfully.");
        }
    }
}

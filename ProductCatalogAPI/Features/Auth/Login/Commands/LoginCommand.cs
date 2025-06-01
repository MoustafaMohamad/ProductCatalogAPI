using ProductCatalogAPI.Common.Helpers.TokenHelper;

namespace ProductCatalogAPI.Features.Auth.Login.Commands
{
    public record LoginCommand(string Username, string Password) : IRequest<RequestResult<string>>;
    public sealed class LoginCommandHandler : BaseRequestHandler<LoginCommand, RequestResult<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenHelper _tokenService;
        public LoginCommandHandler(RequestParameters requestParameters,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenHelper tokenHelper) : base(requestParameters)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenHelper;
        }
        public override async Task<RequestResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user is null)
            {
                return RequestResult<string>.Failure(ErrorCode.Unauthorized);
            }
            if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
            {
                return RequestResult<string>.Failure(ErrorCode.Unauthorized);
            }
            var token = _tokenService.GenerateToken(user);

            return RequestResult<string>.Success(token, "Login successful.");
        }
    }


}

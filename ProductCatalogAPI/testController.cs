using ProductCatalogAPI.Common.Helpers.TokenHelper;

namespace ProductCatalogAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly Context _context;
        private readonly ITokenHelper _tokenHelper;

        public testController(ITokenHelper tokenHelper, Context context)
        {
            _tokenHelper = tokenHelper;
            _context = context;
        }

        [HttpPost]
        public string Get()
        {
            Console.WriteLine($"_context.GetHashCode() in testController {_context.GetHashCode()}"); ;

            var adminUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var user = new User
            {
                Id = adminUserId,
                Username = "admin",
                Name = "Administrator",
                Role = Role.Admin
            };
            return _tokenHelper.GenerateToken(user);
        }

    }
}

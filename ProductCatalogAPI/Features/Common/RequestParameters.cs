


namespace ProductCatalogAPI.Features.Common
{
    public class RequestParameters
    {
        public IMediator Mediator { get; set; }
        public CancellationTokenAccessor CancellationTokenAccessor { get; set; }
        public UserState UserState { get; set; }

        public RequestParameters(IMediator mediator, CancellationTokenAccessor cancellationTokenAccessor, UserState userState)
        {
            Mediator = mediator;
            CancellationTokenAccessor = cancellationTokenAccessor;
            UserState = userState;
        }
    }
}

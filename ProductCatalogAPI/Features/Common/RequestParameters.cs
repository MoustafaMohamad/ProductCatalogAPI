
namespace ProductCatalogAPI.Features.Common
{
    public class RequestParameters
    {
        public IMediator Mediator { get; set; }
        public CancellationTokenAccessor CancellationTokenAccessor { get; set; }

        public RequestParameters(IMediator mediator, CancellationTokenAccessor cancellationTokenAccessor)
        {
            Mediator = mediator;
            CancellationTokenAccessor = cancellationTokenAccessor;
        }
    }
}

namespace ProductCatalogAPI.Features.Common
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IMediator _mediator;
        protected readonly CancellationToken _cancellationToken;
        protected readonly UserState _userState;
        public BaseRequestHandler(RequestParameters requestParameters)
        {
            _mediator = requestParameters.Mediator;
            _cancellationToken = requestParameters.CancellationTokenAccessor.Token;
            _userState = requestParameters.UserState;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}

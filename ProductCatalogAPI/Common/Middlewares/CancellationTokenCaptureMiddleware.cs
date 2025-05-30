namespace ProductCatalogAPI.Common.Middlewares
{
    public class CancellationTokenCaptureMiddleware : IMiddleware
    {
        private CancellationTokenAccessor _cancellationTokenAccessor;
        public CancellationTokenCaptureMiddleware(CancellationTokenAccessor cancellationTokenAccessor)
        {
            _cancellationTokenAccessor = cancellationTokenAccessor;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _cancellationTokenAccessor.Token = context.RequestAborted;

            await next(context);

        }
    }
}

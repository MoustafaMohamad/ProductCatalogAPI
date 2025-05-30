namespace ProductCatalogAPI.Common.Middlewares
{
    public class GlobalErrorHandlerMiddleware : IMiddleware
    {

        private readonly IMediator _mediator;

        public GlobalErrorHandlerMiddleware(IMediator mediator)
        {

            _mediator = mediator;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An unexpected error occurred.");
            }
        }
    }

}
